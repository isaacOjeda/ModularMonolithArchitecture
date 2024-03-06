using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Modular.eShop.Application.Time;
using Modular.eShop.Domain.Primitives;

namespace Modular.eShop.Persistence.Interceptors;

/// <summary>
/// Represents the interceptor for updating auditable entity values.
/// </summary>
public sealed class UpdateAuditableEntitiesInterceptor : SaveChangesInterceptor
{
    private readonly IServiceProvider _serviceProvider;

    public UpdateAuditableEntitiesInterceptor(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    /// <inheritdoc />
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = default)
    {
        if (eventData.Context is null)
        {
            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        using var scope = _serviceProvider.CreateScope();
        var systemTime = scope.ServiceProvider.GetRequiredService<ISystemTime>();

        DateTime utcNow = systemTime.UtcNow;

        foreach (EntityEntry<IAuditable> auditable in GetAuditableEntities(eventData.Context))
        {
            if (auditable.State == EntityState.Added)
            {
                auditable.Property(nameof(IAuditable.CreatedOnUtc)).CurrentValue = utcNow;
            }

            if (auditable.State == EntityState.Modified)
            {
                auditable.Property(nameof(IAuditable.ModifiedOnUtc)).CurrentValue = utcNow;
            }
        }

        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    private static IEnumerable<EntityEntry<IAuditable>> GetAuditableEntities(DbContext dbContext) => dbContext.ChangeTracker.Entries<IAuditable>();
}
