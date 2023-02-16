using Identity.Domain.Entities;

namespace Identity.Application.Common.Abstractions;

public interface IAppDbContext
{
    IQueryable<User> Users { get; }
}