using MediatR;

namespace BrandPromotion.API.Features.Brands.Commands.DeleteBrand;

public class DeleteBrandCommand : IRequest<bool>
{
    public string Id { get; set; } = null!;

    public DeleteBrandCommand(string id) => Id = id;
}
