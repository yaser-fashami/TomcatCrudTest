using Mc2.CrudTest.Core.Contracts.Customers.Queries;
using Mc2.CrudTest.Framework.Infra.Data.Sql.Queries;
using Mc2.CrudTest.Infra.Data.Sql.Queries.Common;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Infra.Data.Sql.Queries.Customer;
public class CustomerQueryRepository : BaseQueryRepository<CrudTestQueryDbContext>, ICustomerQueryRepository
{
    public CustomerQueryRepository(CrudTestQueryDbContext dbContext):base(dbContext)
    {
        
    }

    public async Task<List<Core.Domain.Entities.Customer>> GetAllAsync() => 
        await _dbContext.Customers.ToListAsync();

    async Task<Core.Domain.Entities.Customer?> ICustomerQueryRepository.ExecuteAsync(CustomerQuery query) =>
        await _dbContext.Customers.FirstOrDefaultAsync(c => c.Id.Equals(query));
}
