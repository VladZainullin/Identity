namespace Identity.Application.Features.Authorization.Commands.RegisterUser;

public record RegisterUserDto(
    DateOnly DateOfBirth,
    string Username,
    string Email,
    string Password);