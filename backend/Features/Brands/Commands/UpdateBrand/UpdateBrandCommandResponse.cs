namespace BrandPromotion.API.Features.Brands.Commands.UpdateBrand;

public class UpdateBrandCommandResponse
{
    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string? Logo { get; set; }
    public string? Description { get; set; }
    public string? Website { get; set; }
    public bool IsActive { get; set; }
}
