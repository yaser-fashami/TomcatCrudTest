namespace Mc2.CrudTest.Framework.Core.Domain.ValueObjects;
public abstract class BaseValueObject<TValueObject> : IEquatable<TValueObject>
    where TValueObject : BaseValueObject<TValueObject>
{
    public bool Equals(TValueObject other) => this == other;

    public override bool Equals(object obj)
    {
        if (obj is TValueObject otherObject)
        {
            return GetEqualityComponents().SequenceEqual(otherObject.GetEqualityComponents());
        }
        return false;
    }

    public override int GetHashCode()
    {
        return GetEqualityComponents()
            .Select(x => x != null ? x.GetHashCode() : 0)
            .Aggregate((x, y) => x ^ y);
    }
    protected abstract IEnumerable<object> GetEqualityComponents();
    public abstract bool ObjectIsEqual(TValueObject other);
    public abstract int ObjectGetHashCode();

    public static bool operator == (BaseValueObject<TValueObject> left, BaseValueObject<TValueObject> right)
    {
        if (left is null && left is null)
            return true;
        if (left is null || left is null)
            return false;
        return left.Equals(right);
    }

    public static bool operator !=(BaseValueObject<TValueObject> left, BaseValueObject<TValueObject> right) => !(left == right);
}
