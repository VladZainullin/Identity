using Identity.Application.Features.Authorization.Commands.RegisterUser;
using Identity.Application.Features.Authorization.Commands.SignInUser;
using Identity.Application.Features.Authorization.Commands.SignOutUser;
using Microsoft.AspNetCore.Mvc;

namespace Identity.WebUI.Controllers;

[Route("api/authorization")]
public sealed class AuthorizationController : ApiControllerBase
{
    [HttpPost("sign-up")]
    public async Task<IActionResult> SignUpAsync(
        [FromBody] RegisterUserDto dto,
        CancellationToken cancellationToken)
    {
        await Mediator.Send(
            new RegisterUserCommand(dto),
            cancellationToken);

        return NoContent();
    }

    [HttpPost("sign-in")]
    public async Task<IActionResult> SignInAsync(
        [FromBody] SignInUserDto dto,
        CancellationToken cancellationToken)
    {
        await Mediator.Send(
            new SignInUserCommand(dto),
            cancellationToken);

        return NoContent();
    }
    
    [HttpPost("sign-out")]
    public async Task<IActionResult> SignOutAsync(CancellationToken cancellationToken)
    {
        await Mediator.Send(
            new SignOutUserCommand(),
            cancellationToken);

        return NoContent();
    }
}