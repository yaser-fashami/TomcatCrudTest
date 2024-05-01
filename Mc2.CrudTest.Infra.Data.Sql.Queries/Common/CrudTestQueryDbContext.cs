using Mc2.CrudTest.Core.Domain.Entities;
using Mc2.CrudTest.Framework.Core.Domain.Toolkits.ValueObjects;
using Mc2.CrudTest.Framework.Infra.Data.Sql.Conversions;
using Mc2.CrudTest.Framework.Infra.Data.Sql.Queries;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Infra.Data.Sql.Queries.Common;
public class CrudTestQueryDbContext : BaseQueryDbContext
{
    public CrudTestQueryDbContext(DbContextOptions<CrudTestQueryDbContext> options):base(options)
    {
    }

    public DbSet<Core.Domain.Entities.Customer> Customers { get; set; }



}
