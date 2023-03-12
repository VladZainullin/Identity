using Identity.Domain.Entities;

namespace Identity.Application.Common.Abstractions;

public interface IIdentityService
{
    Task SignUpAsync(
        User user,
        string password);

    Task SignInAsync(
        string username,
        string password,
        bool rememberMe = true);

    Task SignOutAsync();
}