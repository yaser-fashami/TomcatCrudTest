using Mc2.CrudTest.Core.Domain.Entities;
using Mc2.CrudTest.Framework.Core.Contracts.ApplicationServices.Queries;

namespace Mc2.CrudTest.Core.Contracts.Customers.Queries;
public interface ICustomerQueryRepository
{
    public Task<Customer?> ExecuteAsync(CustomerQuery query);
    public Task<List<Customer>> GetAllAsync();
}
