using Mc2.CrudTest.Core.Contracts.Customers.CommandRepositories;
using Mc2.CrudTest.Framework.Infra.Data.Sql.Commands;
using Mc2.CrudTest.Infra.Data.Sql.Coomands.Common;

namespace Mc2.CrudTest.Infra.Data.Sql.Coomands.Customer;
public class CustomerCommandRepository : BaseCommandRepository<Core.Domain.Entities.Customer, CrudTestCommandDbContext, ulong>,
                            ICustomerCommandRepository
{
    public CustomerCommandRepository(CrudTestCommandDbContext dbContext):base(dbContext)
    {
        
    }
}