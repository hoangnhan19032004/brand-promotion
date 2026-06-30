using MediatR;

namespace BrandPromotion.API.Features.Brands.Commands.CreateBrand;

public class CreateBrandCommand : IRequest<CreateBrandCommandResponse>
{
    public string Name { get; set; } = null!;
    public string? Logo { get; set; }
    public string? Description { get; set; }
    public string? Website { get; set; }
}
