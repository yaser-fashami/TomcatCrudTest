using Mc2.CrudTest.Core.Contracts.Customers.Queries;
using Mc2.CrudTest.Framework.Core.ApplicationServices.Queries;
using Mc2.CrudTest.Framework.Core.Contracts.ApplicationServices.Queries;

namespace Mc2.CrudTest.Core.ApplicationService.Blogs.Queries.GetById;

public class GetCustomerByIdQueryHandler : QueryHandler<CustomerQuery, Domain.Entities.Customer?>
{
    private readonly ICustomerQueryRepository _customerQueryRepository;

    public GetCustomerByIdQueryHandler(ICustomerQueryRepository customerQueryRepository)
    {
        _customerQueryRepository = customerQueryRepository;
    }

    public override async Task<QueryResult<Domain.Entities.Customer?>> Handle(CustomerQuery query)
    {
        var customer = await _customerQueryRepository.ExecuteAsync(query);

        return Result(customer);
    }
}
