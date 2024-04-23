using Mc2.CrudTest.Core.Domain.Customer.Events;
using Mc2.CrudTest.Framework.Core.Domain.Entities;
using Mc2.CrudTest.Framework.Core.Domain.Toolkits.ValueObjects;

namespace Mc2.CrudTest.Core.Domain.Customer.Entities;
public class Customer: AggregateRoot
{
    public FirstName FirstName { get; private set; }
    public LastName LastName { get; private set; }
    public DateTime DateOfBirth { get; private set; }
    public PhoneNumber PhoneNumber { get; set; }
    public Email? Email { get; set; }
    public string? BankAcountNumber { get; set; }

    public Customer(FirstName firstName, LastName lastName, DateTime dateOfBirth, PhoneNumber phoneNumber, Email? email, string? bankAcountNumber)
    {
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dateOfBirth;
        PhoneNumber = phoneNumber;
        Email = email;
        BankAcountNumber = bankAcountNumber;
        AddEvent(new CustomerCreated(firstName.Value, lastName.Value, dateOfBirth, phoneNumber.Value, email.Value??string.Empty, bankAcountNumber??string.Empty));
    }

}
