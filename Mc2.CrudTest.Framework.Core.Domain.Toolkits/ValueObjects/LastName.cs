using Mc2.CrudTest.Framework.Core.Domain.Exceptions;
using Mc2.CrudTest.Framework.Core.Domain.ValueObjects;

namespace Mc2.CrudTest.Framework.Core.Domain.Toolkits.ValueObjects;
public class LastName : BaseValueObject<LastName>
{
    #region Properties
    public string Value { get; private set; }
    #endregion

    #region Constructors and Factories
    public static LastName FromString(string value) => new LastName(value);
    public LastName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new InvalidValueObjectStateException("ValidationErrorIsRequire", nameof(LastName));
        }
        if (value.Length < 2 || value.Length > 500)
        {
            throw new InvalidValueObjectStateException("ValidationErrorStringLength", nameof(LastName), "2", "500");
        }
        Value = value;
    }
    private LastName()
    {

    }
    #endregion

    #region Equality Check

    public override int ObjectGetHashCode()
    {
        return Value.GetHashCode();
    }

    public override bool ObjectIsEqual(LastName other)
    {
        return Value == other.Value;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
    #endregion

    #region Operator Overloading
    public static explicit operator string(LastName LastName) => LastName.Value;
    public static implicit operator LastName(string value) => new(value);
    #endregion

    #region Methods
    public override string ToString() => Value;
    #endregion
}
