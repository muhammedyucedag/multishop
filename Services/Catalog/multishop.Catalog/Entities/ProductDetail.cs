using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace multishop.Catalog.Entities;

public class ProductDetail
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = null!;
    public string ProductId { get; set; }

    public string? Description { get; set; }
    public string? ProductInfo { get; set; }

    [BsonIgnore]
    public Product Product { get; set; }
}