using BrandPromotion.API.Models;
using BrandPromotion.API.Repositories.Interfaces;
using MediatR;

namespace BrandPromotion.API.Features.Brands.Commands.CreateBrand;

public class CreateBrandCommandHandler
    : IRequestHandler<CreateBrandCommand, CreateBrandCommandResponse>
{
    private readonly IBrandRepository _brandRepository;

    public CreateBrandCommandHandler(IBrandRepository brandRepository)
    {
        _brandRepository = brandRepository;
    }

    public async Task<CreateBrandCommandResponse> Handle(
        CreateBrandCommand request,
        CancellationToken cancellationToken)
    {
        bool nameExists = await _brandRepository.ExistsByNameAsync(request.Name);
        if (nameExists)
            throw new InvalidOperationException($"Thương hiệu '{request.Name}' đã tồn tại.");

        var brand = new Brand
        {
            Name = request.Name.Trim(),
            Logo = request.Logo,
            Description = request.Description,
            Website = request.Website,
            IsActive = true,
            CreatedAt = DateTime.UtcNow
        };

        var created = await _brandRepository.CreateAsync(brand);

        return new CreateBrandCommandResponse
        {
            Id = created.Id!,
            Name = created.Name,
            Logo = created.Logo,
            Description = created.Description,
            Website = created.Website,
            IsActive = created.IsActive,
            CreatedAt = created.CreatedAt
        };
    }
}
