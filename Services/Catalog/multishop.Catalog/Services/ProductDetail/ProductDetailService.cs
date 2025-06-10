using AutoMapper;
using MongoDB.Driver;
using multishop.Catalog.Dtos.ProductDetail;
using multishop.Catalog.Settings;

namespace multishop.Catalog.Services.ProductDetail;

public class ProductDetailService : IProductDetailService
{
    private readonly IMongoCollection<Entities.ProductDetail> _collection;
    private readonly IMapper _mapper;   

    public ProductDetailService(IMapper mapper, IDatabaseSettings settings)
    {
        var client = new MongoClient(settings.ConnectionString);
        var database = client.GetDatabase(settings.DatabaseName);
        
        _collection = database.GetCollection<Entities.ProductDetail>(settings.ProductDetailCollectionName);
        _mapper = mapper;
    }
    
    public async Task<List<ResultProductDetailDto>> GetAllProductDetailAsync()
    {
        var values = await _collection.Find(x => true).ToListAsync();
        return _mapper.Map<List<ResultProductDetailDto>>(values);
    }

    public async Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto)
    {
        var values = _mapper.Map<Entities.ProductDetail>(createProductDetailDto);
        await _collection.InsertOneAsync(values);
    }

    public async Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto)
    {
        var values = _mapper.Map<Entities.ProductDetail>(updateProductDetailDto);
        await _collection.FindOneAndReplaceAsync(x => x.Id == updateProductDetailDto.Id, values);
    }

    public async Task DeleteProductDetailAsync(string id)
    {
        await _collection.DeleteOneAsync(x => x.Id == id);
    }

    public async Task<GetByIdProductDetailDto> GetByIdProductDetailAsync(string id)
    {
        var values = await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();
        return _mapper.Map<GetByIdProductDetailDto>(values);
    }
}