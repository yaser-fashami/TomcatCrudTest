using Mc2.CrudTest.Framework.Core.Domain.Exceptions;
using Mc2.CrudTest.Framework.Core.Domain.ValueObjects;

namespace Mc2.CrudTest.Framework.Core.Domain.Toolkits.ValueObjects;
public class FirstName : BaseValueObject<FirstName>
{
    #region Properties
    public string Value { get; private set; }
    #endregion

    #region Constructors and Factories
    public static FirstName FromString(string value) => new FirstName(value);
    public FirstName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new InvalidValueObjectStateException("ValidationErrorIsRequire", nameof(FirstName));
        }
        if (value.Length < 2 || value.Length > 250)
        {
            throw new InvalidValueObjectStateException("ValidationErrorStringLength", nameof(FirstName), "2", "250");
        }
        Value = value;
    }
    private FirstName()
    {

    }
    #endregion

    #region Equality Check

    public override int ObjectGetHashCode()
    {
        return Value.GetHashCode();
    }

    public override bool ObjectIsEqual(FirstName other)
    {
        return Value == other.Value;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
    #endregion

    #region Operator Overloading
    public static explicit operator string(FirstName firstName) => firstName.Value;
    public static implicit operator FirstName(string value) => new(value);
    #endregion

    #region Methods
    public override string ToString() => Value;
    #endregion
}
