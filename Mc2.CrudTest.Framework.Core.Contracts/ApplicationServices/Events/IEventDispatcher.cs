using Mc2.CrudTest.Framework.Core.Domain.Events;

namespace Mc2.CrudTest.Framework.Core.Contracts.ApplicationServices.Events;
public interface IEventDispatcher
{
    Task PublishDomainEventAsync<TDomainEvent>(TDomainEvent @event) where TDomainEvent : class, IDomainEvent;
}
