namespace Mc2.CrudTest.Framework.Core.Domain.Entities;
public interface IAuditable
{
    public Guid CreatedByUserId { get; set; }
    public Guid ModifiedByUserId { get; set; }
    public DateTime CreatedDateTime { get; set; }
    public DateTime ModifiedDateTime { get; set; }

}
