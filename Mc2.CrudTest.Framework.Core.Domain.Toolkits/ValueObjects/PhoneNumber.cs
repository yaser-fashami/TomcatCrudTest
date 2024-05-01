using Mc2.CrudTest.Framework.Core.Domain.Exceptions;
using Mc2.CrudTest.Framework.Core.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;
using PhoneNumbers;

namespace Mc2.CrudTest.Framework.Core.Domain.Toolkits.ValueObjects;

public class PhoneNumber: BaseValueObject<PhoneNumber>
{
    #region Properties
    [Phone]
    public string Value { get; private set; }
    #endregion

    #region Constructors and Factories
    public static PhoneNumber FromString(string value) => new PhoneNumber(value);
    public PhoneNumber(string value)
    {
        value = value.Trim();
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new InvalidValueObjectStateException("ValidationErrorIsRequire", nameof(PhoneNumber));
        }
        var phoneNumberUtil = PhoneNumberUtil.GetInstance();
        var phoneNumber = phoneNumberUtil.Parse(value, "IR");
        if (!phoneNumberUtil.IsValidNumber(phoneNumber))
        {
            throw new InvalidValueObjectStateException("ValidationErrorPhonNumber", nameof(PhoneNumber));
        }
        Value = value;
    }
    private PhoneNumber()
    {

    }
    #endregion

    #region Equality Check

    public override int ObjectGetHashCode()
    {
        return Value.GetHashCode();
    }

    public override bool ObjectIsEqual(PhoneNumber other)
    {
        return Value == other.Value;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
    #endregion

    #region Operator Overloading
    public static explicit operator string(PhoneNumber phoneNumber) => phoneNumber.Value;
    public static implicit operator PhoneNumber(string value) => new(value);
    #endregion

    #region Methods
    public override string ToString() => Value;
    #endregion

}
