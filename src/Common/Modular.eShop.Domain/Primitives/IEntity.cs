namespace Modular.eShop.Domain.Primitives;

public interface IEntity
{
    IReadOnlyList<IDomainEvent> GetDomainEvents();

    void ClearDomainEvents();
}
