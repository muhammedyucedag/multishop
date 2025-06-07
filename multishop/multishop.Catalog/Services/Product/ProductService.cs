using AutoMapper;
using MongoDB.Driver;
using multishop.Catalog.Dtos.Product;
using multishop.Catalog.Settings;

namespace multishop.Catalog.Services.Product;

public class ProductService : IProductService
{
    private readonly IMongoCollection<Entities.Product> _collection;
    private readonly IMapper _mapper;   

    public ProductService(IMapper mapper, IDatabaseSettings settings)
    {
        var client = new MongoClient(settings.ConnectionString);
        var database = client.GetDatabase(settings.DatabaseName);
        
        _collection = database.GetCollection<Entities.Product>(settings.ProductCollectionName);
        _mapper = mapper;
    }
    
    public async Task<List<ResultProductDto>> GetAllProductAsync()
    {
        var values = await _collection.Find(x => true).ToListAsync();
        return _mapper.Map<List<ResultProductDto>>(values);
    }

    public async Task CreateProductAsync(CreateProductDto createProductDto)
    {
        var values = _mapper.Map<Entities.Product>(createProductDto);
        await _collection.InsertOneAsync(values);
    }

    public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
    {
        var values = _mapper.Map<Entities.Product>(updateProductDto);
        await _collection.FindOneAndReplaceAsync(x => x.Id == updateProductDto.Id, values);
    }

    public async Task DeleteProductAsync(string id)
    {
        await _collection.DeleteOneAsync(x => x.Id == id);
    }

    public async Task<GetByIdProductDto> GetByIdProductAsync(string id)
    {
        var values = await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();
        return _mapper.Map<GetByIdProductDto>(values);
    }
}