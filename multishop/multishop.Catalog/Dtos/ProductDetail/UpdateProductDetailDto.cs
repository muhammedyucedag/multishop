namespace multishop.Catalog.Dtos.ProductDetail;

public class UpdateProductDetailDto
{
    public string Id { get; set; } = null!;
    public string ProductId { get; set; }

    public string? Description { get; set; }
    public string? ProductInfo { get; set; }
}