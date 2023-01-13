using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Samole.DAL.Framework;

public class AddAuditFeildInterceptor : SaveChangesInterceptor
{
    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        SetShadowProperties(eventData);
        return base.SavingChanges(eventData, result);
    }
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        SetShadowProperties(eventData);
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    private static void SetShadowProperties(DbContextEventData eventData)
    {
        var changeTracker = eventData.Context.ChangeTracker;
        var addedEntities = changeTracker.Entries().Where(e => e.State == EntityState.Added).ToList();
        var modifiedEntities = changeTracker.Entries().Where(e => e.State == EntityState.Modified).ToList();

        var now = DateTime.Now;
        foreach (var item in addedEntities)
        {
            item.Property("CreateBy").CurrentValue = "1";
            item.Property("CreateDate").CurrentValue = now;
        }
        foreach (var item in modifiedEntities)
        {
            item.Property("UpdateBy").CurrentValue = "1";
            item.Property("UpdateDate").CurrentValue = now;
        }
    }

}
