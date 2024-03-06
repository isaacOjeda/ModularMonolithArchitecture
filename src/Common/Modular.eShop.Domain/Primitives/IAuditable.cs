namespace Modular.eShop.Domain.Primitives;

public interface IAuditable
{
    DateTime CreatedOnUtc { get; }

    DateTime? ModifiedOnUtc { get; }
}
