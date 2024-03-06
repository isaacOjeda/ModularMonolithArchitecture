using Microsoft.EntityFrameworkCore;
using Modular.eShop.Catalogs.Application.Common.Interfaces;
using Modular.eShop.Catalogs.Domain.Entities;

namespace Modular.eShop.Catalogs.Persistence;

public class CatalogDbContext : DbContext, ICatalogDbContext
{
    public CatalogDbContext(DbContextOptions<CatalogDbContext> options)
        : base(options)
    {
    }

    public DbSet<Product> Products => Set<Product>();

    public DbSet<ProductType> ProductTypes => Set<ProductType>();

    public DbSet<ProductBrand> ProductBrands => Set<ProductBrand>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        if (modelBuilder is null)
        {
            return;
        }

        modelBuilder.HasDefaultSchema("Catalog");
        modelBuilder.ApplyConfigurationsFromAssembly(AssemblyReference.Assembly);
    }
}
