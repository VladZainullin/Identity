using MediatR;

namespace Identity.Application.Features.Authorization.Commands.RegisterUser;

public record RegisterUserCommand(RegisterUserDto Dto) : IRequest;