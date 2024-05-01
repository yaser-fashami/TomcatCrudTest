namespace Mc2.CrudTest.Framework.Core.Domain.Entities;
public abstract class BaseEntity 
{
    public ulong Id { get; protected set; }
}

public abstract class Entity<TId>
          where TId : struct,
          IComparable,
          IComparable<TId>,
          IConvertible,
          IEquatable<TId>,
          IFormattable
{
    protected Entity() { }

    public ulong Id { get; protected set; }


    #region Equality Check
    public bool Equals(Entity<TId>? other) => this == other;
    public override bool Equals(object? obj) =>
         obj is Entity<TId> otherObject && Id.Equals(otherObject.Id);

    public override int GetHashCode() => Id.GetHashCode();
    public static bool operator ==(Entity<TId> left, Entity<TId> right)
    {
        if (left is null && right is null)
            return true;

        if (left is null || right is null)
            return false;

        return left.Equals(right);
    }

    public static bool operator !=(Entity<TId> left, Entity<TId> right)
        => !(right == left);

    #endregion
}

