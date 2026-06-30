using BrandPromotion.API.Models;

namespace BrandPromotion.API.Repositories.Interfaces;

public interface IBrandRepository
{
    Task<List<Brand>> GetAllAsync();
    Task<Brand?> GetByIdAsync(string id);
    Task<Brand> CreateAsync(Brand brand);
    Task<bool> UpdateAsync(string id, Brand brand);
    Task<bool> DeleteAsync(string id);
    Task<bool> ExistsByNameAsync(string name, string? excludeId = null);
}