using BrandPromotion.API.Models;
using BrandPromotion.API.Repositories.Interfaces;
using BrandPromotion.API.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace BrandPromotion.API.Repositories;

public class BrandRepository : IBrandRepository
{
    private readonly IMongoCollection<Brand> _collection;

    public BrandRepository(IOptions<MongoDbSettings> settings)
    {
        var client = new MongoClient(settings.Value.ConnectionString);
        var database = client.GetDatabase(settings.Value.DatabaseName);
        _collection = database.GetCollection<Brand>("brands");
    }

    public async Task<List<Brand>> GetAllAsync() =>
        await _collection.Find(b => b.IsActive).ToListAsync();

    public async Task<Brand?> GetByIdAsync(string id)
    {
        if (!ObjectId.TryParse(id, out _)) return null; // tránh exception nếu id sai định dạng
        return await _collection.Find(b => b.Id == id).FirstOrDefaultAsync();
    }

    public async Task<Brand> CreateAsync(Brand brand)
    {
        await _collection.InsertOneAsync(brand);
        return brand;
    }

    public async Task<bool> UpdateAsync(string id, Brand brand)
    {
        var result = await _collection.ReplaceOneAsync(b => b.Id == id, brand);
        return result.ModifiedCount > 0;
    }

    public async Task<bool> DeleteAsync(string id)
    {
        var update = Builders<Brand>.Update.Set(b => b.IsActive, false);
        var result = await _collection.UpdateOneAsync(b => b.Id == id, update);
        return result.ModifiedCount > 0;
    }

    public async Task<bool> ExistsByNameAsync(string name, string? excludeId = null)
    {
        var filterBuilder = Builders<Brand>.Filter;
        var filter = filterBuilder.Regex(b => b.Name,
            new BsonRegularExpression($"^{name}$", "i"));

        if (!string.IsNullOrEmpty(excludeId))
            filter &= filterBuilder.Ne(b => b.Id, excludeId);

        return await _collection.Find(filter).AnyAsync();
    }
}