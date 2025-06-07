using AutoMapper;
using MongoDB.Driver;
using multishop.Catalog.Dtos.ProductImage;
using multishop.Catalog.Settings;

namespace multishop.Catalog.Services.ProductImage;

public class ProductImageService : IProductImageService
{
    private readonly IMongoCollection<Entities.ProductImage> _collection;
    private readonly IMapper _mapper;   

    public ProductImageService(IMapper mapper, IDatabaseSettings settings)
    {
        var client = new MongoClient(settings.ConnectionString);
        var database = client.GetDatabase(settings.DatabaseName);
        
        _collection = database.GetCollection<Entities.ProductImage>(settings.ProductImageCollectionName);
        _mapper = mapper;
    }

    public async Task<List<ResultProductImageDto>> GetAllProductImageAsync()
    {
        var values = await _collection.Find(x => true).ToListAsync();
        return _mapper.Map<List<ResultProductImageDto>>(values);
    }

    public async Task CreateProductImageAsync(CreateProductImageDto createProductImageDto)
    {
        
        var value = _mapper.Map<Entities.ProductImage>(createProductImageDto);
        await _collection.InsertOneAsync(value);
    }

    public async Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto)
    {
        var values = _mapper.Map<Entities.ProductImage>(updateProductImageDto);
        await _collection.FindOneAndReplaceAsync(x => x.Id == values.Id, values);
    }

    public async Task DeleteProductImageAsync(string id)
    {
        await _collection.DeleteOneAsync(x => x.Id == id);
    }

    public async Task<GetByIdProductImageDto> GetByIdProductImageAsync(string id)
    {
        var values = await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();
        return _mapper.Map<GetByIdProductImageDto>(values);
    }
}