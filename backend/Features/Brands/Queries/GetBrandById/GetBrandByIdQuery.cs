using BrandPromotion.API.Features.Brands.Queries;
using MediatR;

namespace BrandPromotion.API.Features.Brands.Queries.GetBrandById;

public class GetBrandByIdQuery : IRequest<BrandDto?>
{
    public string Id { get; set; } = null!;

    public GetBrandByIdQuery(string id) => Id = id;
}
