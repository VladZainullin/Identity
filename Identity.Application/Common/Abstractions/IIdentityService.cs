using Identity.Domain.Entities;

namespace Identity.Application.Common.Abstractions;

public interface IIdentityService
{
    Task RegisterAsync(
        User user,
        string password);

    Task LoginAsync(
        string username,
        string password,
        bool rememberMe = true);

    Task LogoutAsync();
}