using Mc2.CrudTest.Core.Contracts.Customers.CommandRepositories;
using Mc2.CrudTest.Core.Contracts.Customers.Commands;
using Mc2.CrudTest.Framework.Core.ApplicationServices.Commands;
using Mc2.CrudTest.Framework.Core.Contracts.ApplicationServices.Commands;

namespace Mc2.CrudTest.Core.ApplicationService.Customer.Commands.CreateCustomer;
public class CreateCustomerCommandHandler : CommandHandler<CreateCustomerCommand>
{
    private readonly ICustomerCommandRepository _customerCommandRepository;
    public CreateCustomerCommandHandler(ICustomerCommandRepository customerCommandRepository)
    {
        _customerCommandRepository = customerCommandRepository;
    }

    public override async Task<CommandResult> Handle(CreateCustomerCommand request)
    {
        Domain.Customer.Entities.Customer customer = new(request.FirstName, request.LastName, request.DateOfBirth, request.PhoneNumber, request.Email, request.BankAcountNumber);
        await _customerCommandRepository.InsertAsync(customer);
        await _customerCommandRepository.CommitAsync();
        return Ok();
    }
}
