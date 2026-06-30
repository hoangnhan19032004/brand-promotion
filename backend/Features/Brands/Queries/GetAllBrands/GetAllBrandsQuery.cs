using BrandPromotion.API.Features.Brands.Queries;
using MediatR;

namespace BrandPromotion.API.Features.Brands.Queries.GetAllBrands;

public class GetAllBrandsQuery : IRequest<List<BrandDto>>
{
}
