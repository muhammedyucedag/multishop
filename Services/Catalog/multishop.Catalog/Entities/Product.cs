using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace multishop.Catalog.Entities;

public class Product
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = null!;
    public string CategoryId { get; set; }

    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public string? ImageUrl { get; set; }
    public string? Description { get; set; }
    
    //Relations
    [BsonIgnore]
    public Category Category { get; set; }
}