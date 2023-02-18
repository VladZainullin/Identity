using MediatR;

namespace Identity.Application.Features.Authorization.Commands.SignInUser;

public record SignInUserCommand(SignInUserDto Dto) : IRequest;