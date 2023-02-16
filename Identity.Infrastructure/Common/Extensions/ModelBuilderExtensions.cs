using Microsoft.EntityFrameworkCore;

namespace Identity.Infrastructure.Common.Extensions;

internal static class ModelBuilderExtensions
{
    public static ModelBuilder RenameIdentityTableName(
        this ModelBuilder builder,
        Func<string, string> rename)
    {
        foreach (var entityType in builder.Model.GetEntityTypes())
        {
            var name = rename?.Invoke(
                entityType.GetTableName() 
                ??
                throw new InvalidOperationException("Table has not name"));
            
            builder
                .Entity(entityType.ClrType)
                .ToTable(name);
        }

        return builder;
    }
}