using System.Security.Claims;
using AutoMapper;
using Identity.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Identity.Application.Features.Authorization.Commands.RegisterUser;

internal sealed class RegisterUserHandler : IRequestHandler<RegisterUserCommand>
{
    private readonly UserManager<User> _userManager;
    private readonly IMapper _mapper;

    public RegisterUserHandler(UserManager<User> userManager, IMapper mapper)
    {
        _userManager = userManager;
        _mapper = mapper;
    }

    public async Task Handle(
        RegisterUserCommand request,
        CancellationToken cancellationToken)
    {
        var user = _mapper.Map<User>(request.Dto);

        var result = await _userManager.CreateAsync(
            user,
            request.Dto.Password);
        if (result != IdentityResult.Success) throw new Exception();

        var claims = new Claim[]
        {
            new(nameof(User.Id), user.Id.ToString()),
            new(nameof(User.Email), user.Email),
            new(nameof(User.UserName), user.UserName)
        };

        await _userManager.AddClaimsAsync(user, claims);
    }
}