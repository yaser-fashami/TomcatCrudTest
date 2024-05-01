using Mc2.CrudTest.Framework.Core.Domain.Toolkits.ValueObjects;
using Mc2.CrudTest.Framework.Infra.Data.Sql.Commands;
using Mc2.CrudTest.Framework.Infra.Data.Sql.Conversions;
using Mc2.CrudTest.Infra.Data.Sql.Coomands.Customer;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Infra.Data.Sql.Coomands.Common;
public class CrudTestCommandDbContext : BaseCommandDbContext
{
    public DbSet<Core.Domain.Entities.Customer> Customers { get; set; }

    public CrudTestCommandDbContext(DbContextOptions<CrudTestCommandDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new CustomerConfig());
    }
}
