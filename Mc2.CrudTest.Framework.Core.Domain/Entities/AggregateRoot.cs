using Mc2.CrudTest.Framework.Core.Domain.Events;
using System.Reflection;

namespace Mc2.CrudTest.Framework.Core.Domain.Entities;
public abstract class AggregateRoot: BaseEntity, IAuditable
{
    private readonly List<IDomainEvent> _events;

    public Guid CreatedByUserId { get; set; }
    public Guid? ModifiedByUserId { get; set; }
    public DateTime CreatedDateTime { get; set; }
    public DateTime? ModifiedDateTime { get; set; }

    protected AggregateRoot() => _events = new();

    public AggregateRoot(IEnumerable<IDomainEvent> events)
    {
        if (events == null || !events.Any()) return;
        foreach (var @event in events)
            ((dynamic)this).On((dynamic)@event);
    }

    protected void AddEvent(IDomainEvent @event) => _events.Add(@event);

    public IEnumerable<IDomainEvent> GetEvents() => _events.AsEnumerable();

    public void ClearEvents() => _events.Clear();
}

