namespace Modular.eShop.Catalogs.Domain.Entities;
public class ProductBrand
{
    public ProductBrand(int id, string brand, string description)
    {
        Id = id;
        Brand = brand;
        Description = description;
    }

    public int Id { get; private set; }

    public string Brand { get; private set; }

    public string Description { get; private set; }
}
