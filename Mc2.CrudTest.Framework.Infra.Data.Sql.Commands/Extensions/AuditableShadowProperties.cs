﻿using Mc2.CrudTest.Framework.Core.Domain.Entities;
using Mc2.CrudTest.Framework.Utilities.Services.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Mc2.CrudTest.Framework.Infra.Data.Sql.Commands.Extensions;

public static class AuditableShadowProperties
{
    public static readonly Func<object, string> EFPropertyCreatedByUserId =
                                    entity => EF.Property<string>(entity, CreatedByUserId);
    public static readonly string CreatedByUserId = nameof(CreatedByUserId);

    public static readonly Func<object, string> EFPropertyModifiedByUserId =
                                    entity => EF.Property<string>(entity, ModifiedByUserId);
    public static readonly string ModifiedByUserId = nameof(ModifiedByUserId);

    public static readonly Func<object, DateTime?> EFPropertyCreatedDateTime =
                                    entity => EF.Property<DateTime?>(entity, CreatedDateTime);
    public static readonly string CreatedDateTime = nameof(CreatedDateTime);

    public static readonly Func<object, DateTime?> EFPropertyModifiedDateTime =
                                    entity => EF.Property<DateTime?>(entity, ModifiedDateTime);
    public static readonly string ModifiedDateTime = nameof(ModifiedDateTime);

    public static void AddAuditableShadowProperties(this ModelBuilder modelBuilder)
    {
        foreach (var entityType in modelBuilder.Model
                                            .GetEntityTypes()
                                            .Where(e=>typeof(IAuditable).IsAssignableFrom(e.ClrType)))
        {
            modelBuilder.Entity(entityType.ClrType)
                        .Property<Guid>(CreatedByUserId);
            modelBuilder.Entity(entityType.ClrType)
                        .Property<Guid?>(ModifiedByUserId);
            modelBuilder.Entity(entityType.ClrType)
                        .Property<DateTime>(CreatedDateTime);
            modelBuilder.Entity(entityType.ClrType)
                        .Property<DateTime?>(ModifiedDateTime);
        }
    }

    public static void SetAuditableEntityPropertyValues(
        this ChangeTracker changeTracker,
        IUserInfoService userInfoService)
    {

        var userAgent = "Test";//userInfoService.GetUserAgent();
        var userIp = "127.0.0.1";//userInfoService.GetUserIp();
        var now = DateTime.UtcNow;
        var userId = new Guid(); //userInfoService.UserId();

        var modifiedEntries = changeTracker.Entries<IAuditable>().Where(x => x.State == EntityState.Modified);
        foreach (var modifiedEntry in modifiedEntries)
        {
            modifiedEntry.Property(ModifiedDateTime).CurrentValue = now;
            modifiedEntry.Property(ModifiedByUserId).CurrentValue = userId;
        }

        var addedEntries = changeTracker.Entries<IAuditable>().Where(x => x.State == EntityState.Added);
        foreach (var addedEntry in addedEntries)
        {
            addedEntry.Property(CreatedDateTime).CurrentValue = now;
            addedEntry.Property(CreatedByUserId).CurrentValue = userId;
        }
    }
}
