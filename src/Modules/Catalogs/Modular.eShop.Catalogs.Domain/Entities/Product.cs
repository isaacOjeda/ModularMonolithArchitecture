using Modular.eShop.Domain.Primitives;

namespace Modular.eShop.Catalogs.Domain.Entities;

/// <summary>
/// Product entity.
/// </summary>
public class Product : Entity<ProductId>, IAuditable
{
    private Product(ProductId id)
        : base(id)
    {
    }

    public string Name { get; private set; } = default!;

    public string Description { get; private set; } = default!;

    public decimal Price { get; private set; }

    public int ProductTypeId { get; private set; }

    public int ProductBrandId { get; private set; }

    public bool Active { get; set; }

    public ProductBrand? ProductBrand { get; private set; }

    public ProductType? ProductType { get; private set; }

    public DateTime CreatedOnUtc { get; private set; }

    public DateTime? ModifiedOnUtc { get; private set; }

    public static Product Create(ProductId id, string name, string description, decimal price, int productTypeId, int productBrandId)
    {
        var product = new Product(id)
        {
            Active = true,
            Name = name,
            Description = description,
            Price = price,
            ProductTypeId = productTypeId,
            ProductBrandId = productBrandId,
        };

        return product;
    }
}
