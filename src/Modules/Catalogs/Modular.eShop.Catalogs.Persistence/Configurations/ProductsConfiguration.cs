using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modular.eShop.Catalogs.Domain.Entities;

namespace Modular.eShop.Catalogs.Persistence.Configurations;
internal class ProductsConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(q => q.Id);

        builder.Property(q => q.Id)
            .HasConversion(v => v.Value, v => new ProductId(v));

        builder.Property(q => q.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(q => q.Description)
            .HasMaxLength(500)
            .IsRequired();

        builder.Property(q => q.Price)
            .HasColumnType("decimal(18,2)")
            .IsRequired();
    }
}
