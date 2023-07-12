using Microsoft.EntityFrameworkCore;
using RpgItemsCatalogApi.Domain.Data.Mapping;
using RpgItemsCatalogApi.Domain.Models;

namespace RpgItemsCatalogApi.Domain.Data;

public class CatalogContext : DbContext
{
    public CatalogContext(DbContextOptions<CatalogContext> options)
        : base(options) { }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CategoryMap());
        modelBuilder.ApplyConfiguration(new ProductMap());
    }
}
