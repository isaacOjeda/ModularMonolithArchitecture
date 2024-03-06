namespace Modular.eShop.Domain.Primitives;

public abstract class Entity<TEntityId> : IEntity
    where TEntityId : class, IEntityId
{
    private readonly List<IDomainEvent> _domainEvents = new();

    protected Entity(TEntityId id)
        : this() =>
        Id = id ?? throw new ArgumentException("The entity identifier is required.", nameof(id));

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    protected Entity()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    {
    }

    public TEntityId Id { get; private init; }

    public IReadOnlyList<IDomainEvent> GetDomainEvents() => _domainEvents.ToList();

    public void ClearDomainEvents() => _domainEvents.Clear();

    protected void RaiseDomainEvent(IDomainEvent domainEvent) => _domainEvents.Add(domainEvent);
}
