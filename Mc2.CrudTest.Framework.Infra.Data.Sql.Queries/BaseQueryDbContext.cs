using Mc2.CrudTest.Framework.Core.Domain.Toolkits.ValueObjects;
using Mc2.CrudTest.Framework.Infra.Data.Sql.Conversions;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Framework.Infra.Data.Sql.Queries;
public abstract class BaseQueryDbContext : DbContext
{
    protected BaseQueryDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<FirstName>().HaveConversion<FirstNameConversion>();
        configurationBuilder.Properties<LastName>().HaveConversion<LastNameConversion>();
        configurationBuilder.Properties<PhoneNumber>().HaveConversion<PhoneNumberConversion>();
        configurationBuilder.Properties<Email>().HaveConversion<EmailConversion>();
    }

    public sealed override int SaveChanges()
    {
        throw new NotSupportedException();
    }
    public sealed override int SaveChanges(bool acceptAllChangesOnSuccess)
    {
        throw new NotSupportedException();
    }
    public sealed override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
    {
        throw new NotSupportedException();
    }
    public sealed override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        throw new NotSupportedException();
    }
}
