using BrandPromotion.API.Repositories.Interfaces;
using MediatR;

namespace BrandPromotion.API.Features.Brands.Commands.UpdateBrand;

public class UpdateBrandCommandHandler
    : IRequestHandler<UpdateBrandCommand, UpdateBrandCommandResponse?>
{
    private readonly IBrandRepository _brandRepository;

    public UpdateBrandCommandHandler(IBrandRepository brandRepository)
    {
        _brandRepository = brandRepository;
    }

    public async Task<UpdateBrandCommandResponse?> Handle(
        UpdateBrandCommand request,
        CancellationToken cancellationToken)
    {
        var existing = await _brandRepository.GetByIdAsync(request.Id);
        if (existing is null)
            return null; 

        bool nameExists = await _brandRepository.ExistsByNameAsync(request.Name, excludeId: request.Id);
        if (nameExists)
            throw new InvalidOperationException($"Thương hiệu '{request.Name}' đã tồn tại.");

        existing.Name = request.Name.Trim();
        existing.Logo = request.Logo;
        existing.Description = request.Description;
        existing.Website = request.Website;
        existing.IsActive = request.IsActive;

        await _brandRepository.UpdateAsync(request.Id, existing);

        return new UpdateBrandCommandResponse
        {
            Id = existing.Id!,
            Name = existing.Name,
            Logo = existing.Logo,
            Description = existing.Description,
            Website = existing.Website,
            IsActive = existing.IsActive
        };
    }
}
