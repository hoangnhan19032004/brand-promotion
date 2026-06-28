using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BrandPromotion.API.Models;

public class Brand
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("name")]
    public string Name { get; set; } = null!;

    [BsonElement("logo")]
    public string? Logo { get; set; }

    [BsonElement("description")]
    public string? Description { get; set; }

    [BsonElement("website")]
    public string? Website { get; set; }

    [BsonElement("isActive")]
    public bool IsActive { get; set; } = true;

    [BsonElement("createdAt")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}