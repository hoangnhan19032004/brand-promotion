using BrandPromotion.API.Models;

namespace BrandPromotion.API.Services.Interfaces;

public interface IBrandService
{
    Task<List<Brand>> GetAllAsync();
    
}