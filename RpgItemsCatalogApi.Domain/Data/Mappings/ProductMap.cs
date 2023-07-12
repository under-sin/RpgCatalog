using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RpgItemsCatalogApi.Domain.Models;

namespace RpgItemsCatalogApi.Domain.Data.Mapping;

public class ProductMap : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Product");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder.Property(x => x.Name)
            .IsRequired()
            .HasColumnName("Name")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(80);

        builder.Property(x => x.Description)
            .IsRequired()
            .HasColumnName("Description")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(260);

        builder.Property(x => x.UrlImg)
            .HasColumnName("UrlImg")
            .HasColumnType("VARCHAR")
            .HasMaxLength(1000);

        builder.Property(x => x.Price)
            .IsRequired()
            .HasColumnName("Price")
            .HasColumnType("DECIMAL");

        builder.HasMany(x => x.Categories)
            .WithMany(x => x.Products)
            .UsingEntity(j => j.ToTable("ProductCategory"));
    }
}
