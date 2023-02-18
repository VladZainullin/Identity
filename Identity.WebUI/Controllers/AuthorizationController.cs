using Identity.Application.Features.Authorization.Commands.RegisterUser;
using Microsoft.AspNetCore.Mvc;

namespace Identity.WebUI.Controllers;

[Route("authorization")]
public sealed class AuthorizationController : ApiControllerBase
{
    [HttpPost]
    public async Task<IActionResult> RegisterUserAsync(
        [FromBody] RegisterUserDto dto,
        CancellationToken cancellationToken)
    {
        await Mediator.Send(
            new RegisterUserCommand(dto),
            cancellationToken);
        
        return NoContent();
    }
}