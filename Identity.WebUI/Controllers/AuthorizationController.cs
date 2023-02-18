using Identity.Application.Features.Authorization.Commands.RegisterUser;
using Identity.Application.Features.Authorization.Commands.SignInUser;
using Microsoft.AspNetCore.Mvc;

namespace Identity.WebUI.Controllers;

[Route("authorization")]
public sealed class AuthorizationController : ApiControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> RegisterUserAsync(
        [FromBody] RegisterUserDto dto,
        CancellationToken cancellationToken)
    {
        await Mediator.Send(
            new RegisterUserCommand(dto),
            cancellationToken);

        return NoContent();
    }

    [HttpPost("sign-in")]
    public async Task<IActionResult> SignInUserAsync(
        [FromBody] SignInUserDto dto,
        CancellationToken cancellationToken)
    {
        await Mediator.Send(
            new SignInUserCommand(dto),
            cancellationToken);

        return NoContent();
    }
}