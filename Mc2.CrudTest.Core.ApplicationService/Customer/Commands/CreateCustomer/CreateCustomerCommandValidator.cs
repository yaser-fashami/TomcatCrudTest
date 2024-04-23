using Mc2.CrudTest.Core.Contracts.Customers.Commands;
using FluentValidation;
using Mc2.CrudTest.Framework.Core.Domain.Toolkits.ValueObjects;

namespace Mc2.CrudTest.Core.ApplicationService.Customer.Commands.CreateCustomer;
public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
{
    public CreateCustomerCommandValidator()
    {
        RuleFor(c => c.FirstName)
            .NotEmpty().WithMessage(nameof(FirstName))
            .MinimumLength(2).WithMessage(nameof(FirstName))
            .MaximumLength(250).WithMessage(nameof(FirstName));

        RuleFor(c => c.LastName)
            .NotEmpty().WithMessage(nameof(LastName))
            .MinimumLength(2).WithMessage(nameof(LastName))
            .MaximumLength(500).WithMessage(nameof(LastName));

        RuleFor(c => c.DateOfBirth)
            .NotEmpty().WithMessage("DateOfBirth");

        RuleFor(c=>c.PhoneNumber)
            .NotEmpty().WithMessage(nameof(PhoneNumber))
            .MaximumLength(12).WithMessage(nameof(PhoneNumber));

        RuleFor(c => c.Email)
            .EmailAddress().WithMessage(nameof(Email));


    }
}

