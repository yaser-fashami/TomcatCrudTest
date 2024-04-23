
using Mc2.CrudTest.Framework.Core.Contracts.ApplicationServices.Commands;

namespace Mc2.CrudTest.Core.Contracts.Customers.Commands;
public class CreateCustomerCommand : ICommand
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string PhoneNumber { get; set; }
    public string? Email { get; set; }
    public string? BankAcountNumber { get; set; }

}
