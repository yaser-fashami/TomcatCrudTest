using Mc2.CrudTest.Framework.Core.Domain.Events;

namespace Mc2.CrudTest.Framework.Core.Contracts.ApplicationServices.Events;
public interface IDomainEventHandler<TDomainEvent>
    where TDomainEvent : IDomainEvent
{
    Task Handle(TDomainEvent Event);
}
