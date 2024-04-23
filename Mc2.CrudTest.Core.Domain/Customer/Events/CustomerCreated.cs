using Mc2.CrudTest.Framework.Core.Domain.Events;
using Mc2.CrudTest.Framework.Core.Domain.Toolkits.ValueObjects;

namespace Mc2.CrudTest.Core.Domain.Customer.Events;
public class CustomerCreated : IDomainEvent
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public DateTime DateOfBirth { get; private set; }
    public string PhoneNumber { get; private set; }
    public string? Email { get; private set; }
    public string? BankAcountNumber { get; private set; }

    public CustomerCreated(string firstName, string lastName, DateTime dateOfBirth, string phoneNumber, string? email, string? bankAccountNumber)
    {
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dateOfBirth;
        PhoneNumber = phoneNumber;
        Email = email;
        BankAcountNumber = bankAccountNumber;
    }
}
