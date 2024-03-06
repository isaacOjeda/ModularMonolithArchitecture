namespace Modular.eShop.Domain.Primitives;

public abstract record DomainEvent : IDomainEvent
{
    protected DomainEvent(Guid id, DateTime occurredOnUtc)
        : this()
    {
        Id = id;
        OccurredOnUtc = occurredOnUtc;
    }

    private DomainEvent()
    {
    }

    public Guid Id { get; private set; }

    public DateTime OccurredOnUtc { get; private set; }
}
