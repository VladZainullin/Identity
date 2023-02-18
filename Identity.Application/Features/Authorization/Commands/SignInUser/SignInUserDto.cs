namespace Identity.Application.Features.Authorization.Commands.SignInUser;

public record SignInUserDto(
    string Username,
    string Password,
    bool RememberMe);