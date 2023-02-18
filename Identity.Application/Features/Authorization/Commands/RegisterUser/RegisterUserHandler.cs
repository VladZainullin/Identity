using System.Security.Claims;
using Identity.Application.Common.Abstractions;
using Identity.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Identity.Application.Features.Authorization.Commands.RegisterUser;

internal sealed class RegisterUserHandler : IRequestHandler<RegisterUserCommand>
{
    private readonly IAppDbContext _context;
    private readonly UserManager<User> _userManager;

    public RegisterUserHandler(
        IAppDbContext context,
        UserManager<User> userManager)
    {
        _context = context;
        _userManager = userManager;
    }
    
    public async Task Handle(
        RegisterUserCommand request,
        CancellationToken cancellationToken)
    {
        var dto = request.Dto;
        
        var user = new User
        {
            DateOfBirth = dto.DateOfBirth,
            UserName = dto.Username,
            Email = dto.Email,
        };

        var result = await _userManager.CreateAsync(user, dto.Password);
        if (result != IdentityResult.Success)
        {
            throw new Exception();
        }

        var claims = new Claim[]
        {
            new(nameof(User.Id), user.Id.ToString()),
            new(nameof(User.Email), user.Email),
            new(nameof(User.UserName), user.UserName),
        };

        await _userManager.AddClaimsAsync(user, claims);
    }
}