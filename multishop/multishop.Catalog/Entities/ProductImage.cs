namespace multishop.Catalog.Entities;

public class ProductImage
{
    public string Id { get; set; } = null!;
    public string ProductId { get; set; } 
    
    public string Image1 { get; set; }
    public string Image2 { get; set; }
    public string Image3 { get; set; }
    
    //Relations
    public Product Product { get; set; }
}