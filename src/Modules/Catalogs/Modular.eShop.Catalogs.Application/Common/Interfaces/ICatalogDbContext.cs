using Microsoft.EntityFrameworkCore;
using Modular.eShop.Catalogs.Domain.Entities;

namespace Modular.eShop.Catalogs.Application.Common.Interfaces;

public interface ICatalogDbContext
{
    DbSet<Product> Products { get; }

    DbSet<ProductType> ProductTypes { get; }

    DbSet<ProductBrand> ProductBrands { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
