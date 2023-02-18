using Identity.Application.Common.Abstractions;
using Identity.Domain.Entities;
using Identity.Infrastructure.Common.Exceptions;
using Microsoft.AspNetCore.Identity;

namespace Identity.Infrastructure.Services;

internal sealed class IdentityService : IIdentityService
{
    private readonly SignInManager<User> _signInManager;
    private readonly UserManager<User> _userManager;

    public IdentityService(
        UserManager<User> userManager,
        SignInManager<User> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async Task RegisterAsync(
        User user,
        string password)
    {
        var result = await _userManager.CreateAsync(
            user,
            password);

        if (result != IdentityResult.Success)
        {
            var message = result.Errors.Select(e => e.Description).First();
            throw new IdentityException(message);
        }
    }

    public async Task LoginAsync(
        string username,
        string password,
        bool rememberMe = true)
    {
        var result = await _signInManager.PasswordSignInAsync(
            username,
            password,
            rememberMe,
            false);

        if (!result.Succeeded) throw new IdentityException("Неверное имя пользователя или пароль");
    }

    public async Task LogoutAsync()
    {
        await _signInManager.SignOutAsync();
    }
}