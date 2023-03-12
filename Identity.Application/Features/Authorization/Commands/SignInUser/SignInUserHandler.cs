using Identity.Application.Common.Abstractions;
using MediatR;

namespace Identity.Application.Features.Authorization.Commands.SignInUser;

internal sealed class SignInUserHandler : IRequestHandler<SignInUserCommand>
{
    private readonly IIdentityService _identityService;

    public SignInUserHandler(IIdentityService identityService)
    {
        _identityService = identityService;
    }
    
    public async Task Handle(
        SignInUserCommand request,
        CancellationToken cancellationToken)
    {
        await _identityService.SignInAsync(
            request.Dto.Username,
            request.Dto.Password,
            request.Dto.RememberMe);
    }
}