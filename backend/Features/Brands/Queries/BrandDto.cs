namespace BrandPromotion.API.Features.Brands.Queries;

public class BrandDto
{
    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string? Logo { get; set; }
    public string? Description { get; set; }
    public string? Website { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
}
