namespace RpgItemsCatalogApi.Domain.Models;

public class Category
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public IList<Product> Products { get; set; }
}
