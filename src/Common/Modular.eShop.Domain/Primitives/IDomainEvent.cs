using MediatR;

namespace Modular.eShop.Domain.Primitives;

public interface IDomainEvent : INotification
{
    Guid Id { get; }

    DateTime OccurredOnUtc { get; }
}
