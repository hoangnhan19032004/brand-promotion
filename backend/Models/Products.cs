using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BrandPromotion.API.Models;

public class Product
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("name")]
    public string Name { get; set; } = null!;

    [BsonRepresentation(BsonType.ObjectId)]
    [BsonElement("brandId")]
    public string BrandId { get; set; } = null!;

    [BsonElement("price")]
    public decimal Price { get; set; }

    [BsonElement("discountPrice")]
    public decimal? DiscountPrice { get; set; }

    [BsonElement("description")]
    public string? Description { get; set; }

    [BsonElement("images")]
    public List<string> Images { get; set; } = [];

    [BsonElement("tags")]
    public List<string> Tags { get; set; } = [];

    [BsonElement("isFeatured")]
    public bool IsFeatured { get; set; } = false;

    [BsonElement("isActive")]
    public bool IsActive { get; set; } = true;

    [BsonElement("createdAt")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}