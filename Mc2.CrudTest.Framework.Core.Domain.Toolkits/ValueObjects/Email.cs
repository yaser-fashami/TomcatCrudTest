using Mc2.CrudTest.Framework.Core.Domain.Exceptions;
using Mc2.CrudTest.Framework.Core.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace Mc2.CrudTest.Framework.Core.Domain.Toolkits.ValueObjects;

public class Email: BaseValueObject<Email>
{
    #region Properties
    [EmailAddress]
    public string Value { get; private set; }
    #endregion

    #region Constructors and Factories
    public static Email FromString(string value) => new Email(value);
    public Email(string value)
    {
        if (value.Length < 7)
        {
            throw new InvalidValueObjectStateException("ValidationErrorEmail", nameof(Email));
        }
        if (!value.Contains('@') || !value.Contains('.'))
        {
            throw new InvalidValueObjectStateException("ValidationErrorEmail", nameof(Email));
        }
        Value = value;
    }
    private Email()
    {

    }
    #endregion

    #region Equality Check

    public override int ObjectGetHashCode()
    {
        return Value.GetHashCode();
    }

    public override bool ObjectIsEqual(Email other)
    {
        return Value == other.Value;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
    #endregion

    #region Operator Overloading
    public static explicit operator string(Email Email) => Email.Value;
    public static implicit operator Email(string value) => new(value);
    #endregion

    #region Methods
    public override string ToString() => Value;
    #endregion

}
