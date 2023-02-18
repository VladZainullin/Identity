using AutoMapper;
using Identity.Application.Common.Abstractions;
using Identity.Domain.Entities;
using MediatR;

namespace Identity.Application.Features.Authorization.Commands.RegisterUser;

internal sealed class RegisterUserHandler : IRequestHandler<RegisterUserCommand>
{
    private readonly IIdentityService _identityService;
    private readonly IMapper _mapper;

    public RegisterUserHandler(
        IIdentityService identityService,
        IMapper mapper)
    {
        _identityService = identityService;
        _mapper = mapper;
    }

    public async Task Handle(
        RegisterUserCommand request,
        CancellationToken cancellationToken)
    {
        var user = _mapper.Map<User>(request.Dto);

        await _identityService.RegisterAsync(user, request.Dto.Password);
    }
}