using AutoMapper;
using Identity.Domain.Entities;

namespace Identity.Application.Features.Authorization.Commands.RegisterUser;

internal sealed class RegisterUserProfile : Profile
{
    public RegisterUserProfile()
    {
        CreateMap<RegisterUserDto, User>();
    }
}