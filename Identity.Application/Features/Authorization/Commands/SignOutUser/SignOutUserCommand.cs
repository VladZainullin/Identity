using MediatR;

namespace Identity.Application.Features.Authorization.Commands.SignOutUser;

public record SignOutUserCommand : IRequest;