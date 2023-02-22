namespace Code4Nothing.SharedDefinitions.DomainAbstracts;

public abstract record BaseDomainEntity : IDomainEvent
{
    private readonly List<INotification> _domainEvents = new();
    
    public IEnumerable<INotification> GetDomainEvents() => _domainEvents;

    public void AddDomainEvent(INotification @event) => _domainEvents.Add(@event);

    public void AddDomainEventIfAbsent(INotification @event)
    {
        if (!_domainEvents.Contains(@event)) _domainEvents.Add(@event);
    }

    public void ClearDomainEvents() => _domainEvents.Clear();
}
