using Microsoft.AspNetCore.Identity;

namespace Identity.Domain.Entities;

public sealed class User : IdentityUser<Guid>
{
    public DateOnly DateOfBirth { get; set; }

    public override string Email { get; set; } = null!;
    
    public override string UserName { get; set; } = null!;
}