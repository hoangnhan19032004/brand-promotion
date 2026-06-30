using BrandPromotion.API.Features.Brands.Queries;
using BrandPromotion.API.Repositories.Interfaces;
using MediatR;

namespace BrandPromotion.API.Features.Brands.Queries.GetBrandById;

public class GetBrandByIdQueryHandler
    : IRequestHandler<GetBrandByIdQuery, BrandDto?>
{
    private readonly IBrandRepository _brandRepository;

    public GetBrandByIdQueryHandler(IBrandRepository brandRepository)
    {
        _brandRepository = brandRepository;
    }

    public async Task<BrandDto?> Handle(
        GetBrandByIdQuery request,
        CancellationToken cancellationToken)
    {
        var brand = await _brandRepository.GetByIdAsync(request.Id);
        if (brand is null) return null;

        return new BrandDto
        {
            Id = brand.Id!,
            Name = brand.Name,
            Logo = brand.Logo,
            Description = brand.Description,
            Website = brand.Website,
            IsActive = brand.IsActive,
            CreatedAt = brand.CreatedAt
        };
    }
}
