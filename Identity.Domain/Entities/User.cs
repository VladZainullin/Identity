using Microsoft.AspNetCore.Identity;

namespace Identity.Domain.Entities;

public sealed class User : IdentityUser<Guid>
{
    public DateTime DateOfBirth { get; set; }
}