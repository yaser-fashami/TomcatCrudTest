using Mc2.CrudTest.Framework.Infra.Data.Sql.Commands.Extensions;
using Mc2.CrudTest.Framework.Utilities.Services.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace Mc2.CrudTest.Framework.Infra.Data.Sql.Commands;

public abstract class BaseCommandDbContext : DbContext
{
    private IDbContextTransaction _transaction;

    protected BaseCommandDbContext()
    {
    }

    public BaseCommandDbContext(DbContextOptions options): base(options)
    {
        
    }

    public void BeginTransaction()
    {
        _transaction = Database.BeginTransaction();
    }
    public void Rollback()
    {
        if (_transaction == null)
        {
            throw new NullReferenceException("Please call `BeginTransaction()` method first.");
        }
        _transaction.Rollback();
    }
    public void Commit()
    {
        if (_transaction == null)
        {
            throw new NullReferenceException("Please call `BeginTransaction()` method first.");
        }
        _transaction.Commit();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.AddAuditableShadowProperties();
    }

    public override int SaveChanges()
    {
        ChangeTracker.DetectChanges();
        SetShadowProperties();
        ChangeTracker.AutoDetectChangesEnabled = false;
        var result = base.SaveChanges();
        ChangeTracker.AutoDetectChangesEnabled = true;
        return result;
    }
    public override Task<int> SaveChangesAsync(
        bool acceptAllChangesOnSuccess,
        CancellationToken cancellationToken = default)
    {
        ChangeTracker.DetectChanges();
        SetShadowProperties();
        ChangeTracker.AutoDetectChangesEnabled = false;
        var result = base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        ChangeTracker.AutoDetectChangesEnabled = true;
        return result;
    }


    private void SetShadowProperties()
    {
        var userInfoService = this.GetService<IUserInfoService>();
        ChangeTracker.SetAuditableEntityPropertyValues(userInfoService);
    }
}
