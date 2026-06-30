using BrandPromotion.API.Repositories.Interfaces;
using MediatR;

namespace BrandPromotion.API.Features.Brands.Commands.DeleteBrand;

public class DeleteBrandCommandHandler
    : IRequestHandler<DeleteBrandCommand, bool>
{
    private readonly IBrandRepository _brandRepository;

    public DeleteBrandCommandHandler(IBrandRepository brandRepository)
    {
        _brandRepository = brandRepository;
    }

    public async Task<bool> Handle(
        DeleteBrandCommand request,
        CancellationToken cancellationToken)
    {
        var existing = await _brandRepository.GetByIdAsync(request.Id);
        if (existing is null)
            return false;

        return await _brandRepository.DeleteAsync(request.Id);
    }
}
