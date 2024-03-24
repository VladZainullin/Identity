using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[ApiController]
[AllowAnonymous]
[Route("api/accounts")]
public sealed class AccountsController(SignInManager<IdentityUser<Guid>> signInManager) : ControllerBase
{
    [HttpPost("sign-up")]
    public async Task<ActionResult> SignUpAsync()
    {
        const string email = "mittoface02@mail.ru";
        const string username = "VladislavZainullin";
        const string password = "Vl24082002.";
        
        var user = new IdentityUser<Guid>
        {
            Email = email,
            UserName = username,
        };

        var identityResult = await signInManager.UserManager.CreateAsync(user, password);
        if (identityResult.Succeeded)
        {
            return NoContent();
        }

        return Unauthorized();
    }

    [HttpPost("sign-in")]
    public async Task<ActionResult> SignInAsync()
    {
        const string email = "mittoface02@mail.ru";
        const string password = "Vl24082002.";

        var user = await signInManager.UserManager.FindByEmailAsync(email);
        if (ReferenceEquals(user, default))
        {
            return Unauthorized();
        }

        var signInResult = await signInManager.CheckPasswordSignInAsync(user, password, false);
        if (signInResult.Succeeded)
        {
            return NoContent();
        }
        
        return Unauthorized();
    }

    [HttpPost("sign-out")]
    public async Task<NoContentResult> SignOutAsync()
    {
        await signInManager.SignOutAsync();

        return NoContent();
    }
}