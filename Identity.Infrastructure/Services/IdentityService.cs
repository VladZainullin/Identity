using Identity.Application.Common.Abstractions;
using Identity.Domain.Entities;
using Identity.Infrastructure.Common.Exceptions;
using Microsoft.AspNetCore.Identity;

namespace Identity.Infrastructure.Services;

internal sealed class IdentityService : IIdentityService
{
    private readonly SignInManager<User> _signInManager;

    public IdentityService(SignInManager<User> signInManager)
    {
        _signInManager = signInManager;
    }

    public async Task SignUpAsync(
        User user,
        string password)
    {
        var result = await _signInManager.UserManager.CreateAsync(
            user,
            password);

        if (result != IdentityResult.Success)
        {
            var message = result.Errors.Select(e => e.Description).First();
            throw new IdentityException(message);
        }
    }

    public async Task SignInAsync(
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

    public Task SignOutAsync()
    {
        return _signInManager.SignOutAsync();
    }
}