namespace Code4Nothing.SharedDefinitions.DomainAbstracts;

public interface IDomainEvent
{
    IEnumerable<INotification> GetDomainEvents();
    void AddDomainEvent(INotification @event);
    void AddDomainEventIfAbsent(INotification @event);
    void ClearDomainEvents();
}
