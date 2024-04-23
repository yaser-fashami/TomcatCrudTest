namespace Mc2.CrudTest.Framework.Core.Domain.Entities;
public abstract class BaseEntity : IAuditable
{
    public ulong Id { get; protected set; }
    public Guid CreatedByUserId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public Guid ModifiedByUserId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public DateTime CreatedDateTime { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public DateTime ModifiedDateTime { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    protected BaseEntity()
    {
        
    }
}
