namespace multishop.Catalog.Dtos.ProductImage;

public class UpdateProductImageDto
{
    public string Id { get; set; } = null!;
    public string ProductId { get; set; } 
    
    public string Image1 { get; set; }
    public string Image2 { get; set; }
    public string Image3 { get; set; }
}