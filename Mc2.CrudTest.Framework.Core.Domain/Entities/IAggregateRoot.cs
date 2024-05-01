using Mc2.CrudTest.Framework.Core.Domain.Events;

namespace Mc2.CrudTest.Framework.Core.Domain.Entities;
public interface IAggregateRoot
{
    void ClearEvents();
    IEnumerable<IDomainEvent> GetEvents();

}
