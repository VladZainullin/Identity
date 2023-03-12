using Identity.Application.Common.Abstractions;
using MediatR;

namespace Identity.Application.Features.Authorization.Commands.SignOutUser;

internal sealed class SignOutUserHandler : IRequestHandler<SignOutUserCommand>
{
    private readonly IIdentityService _identityService;

    public SignOutUserHandler(IIdentityService identityService)
    {
        _identityService = identityService;
    }
    
    public async Task Handle(
        SignOutUserCommand request,
        CancellationToken cancellationToken)
    {
        await _identityService.SignOutAsync();
    }
}