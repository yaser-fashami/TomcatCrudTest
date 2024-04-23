using Mc2.CrudTest.Framework.Infra.Data.Sql.Queries;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Infra.Data.Sql.Queries.Common;
public class CrudTestQueryDbContext : BaseQueryDbContext
{
    public CrudTestQueryDbContext(DbContextOptions options):base(options)
    {
        
    }
}
