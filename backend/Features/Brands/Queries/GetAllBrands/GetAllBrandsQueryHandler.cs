using BrandPromotion.API.Features.Brands.Queries;
using BrandPromotion.API.Repositories.Interfaces;
using MediatR;

namespace BrandPromotion.API.Features.Brands.Queries.GetAllBrands;

public class GetAllBrandsQueryHandler
    : IRequestHandler<GetAllBrandsQuery, List<BrandDto>>
{
    private readonly IBrandRepository _brandRepository;

    public GetAllBrandsQueryHandler(IBrandRepository brandRepository)
    {
        _brandRepository = brandRepository;
    }

    public async Task<List<BrandDto>> Handle(
        GetAllBrandsQuery request,
        CancellationToken cancellationToken)
    {
        var brands = await _brandRepository.GetAllAsync();

        return brands.Select(b => new BrandDto
        {
            Id = b.Id!,
            Name = b.Name,
            Logo = b.Logo,
            Description = b.Description,
            Website = b.Website,
            IsActive = b.IsActive,
            CreatedAt = b.CreatedAt
        }).ToList();
    }
}
