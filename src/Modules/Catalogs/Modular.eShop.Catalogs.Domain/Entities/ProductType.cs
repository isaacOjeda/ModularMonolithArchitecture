namespace Modular.eShop.Catalogs.Domain.Entities;

/// <summary>
/// product type.
/// </summary>
public class ProductType
{
    public ProductType(int id, string type, string description)
    {
        Id = id;
        Type = type;
        Description = description;
    }

    /// <summary>
    /// product type id.
    /// </summary>
    public int Id { get; private set; }

    /// <summary>
    /// type of the product.
    /// </summary>
    public string Type { get; private set; }

    /// <summary>
    /// description of the product type.
    /// </summary>
    public string Description { get; private set; }
}
