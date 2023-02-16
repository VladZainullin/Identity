using Identity.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Identity.Application.Common.Abstractions;

public interface IAppDbContext
{
    DbSet<User> Users { get; }
}