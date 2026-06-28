using BrandPromotion.API.Models;
using BrandPromotion.API.Services.Interfaces;
using BrandPromotion.API.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BrandPromotion.API.Services;

public class BrandService : IBrandService
{
    private readonly IMongoCollection<Brand> _brands;

    public BrandService(IOptions<MongoDbSettings> settings)
    {
        var client = new MongoClient(settings.Value.ConnectionString);
        var database = client.GetDatabase(settings.Value.DatabaseName);
        _brands = database.GetCollection<Brand>("brands");
    }

    public async Task<List<Brand>> GetAllAsync() =>
        await _brands.Find(b => b.IsActive).ToListAsync();

    


}