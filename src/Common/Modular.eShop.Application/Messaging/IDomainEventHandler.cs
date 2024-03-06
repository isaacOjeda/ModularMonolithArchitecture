using MediatR;
using Modular.eShop.Domain.Primitives;

namespace Modular.eShop.Application.Messaging;

public interface IDomainEventHandler<in TEvent> : INotificationHandler<TEvent>
    where TEvent : IDomainEvent
{
}
