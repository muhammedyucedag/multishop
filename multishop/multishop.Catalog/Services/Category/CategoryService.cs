using AutoMapper;
using MongoDB.Driver;
using multishop.Catalog.Dtos.Category;
using multishop.Catalog.Settings;

namespace multishop.Catalog.Services.Category;

public class CategoryService : ICategoryService
{
    private readonly IMongoCollection<Entities.Category> _collection;
    private readonly IMapper _mapper;   

    public CategoryService(IMapper mapper, IDatabaseSettings settings)
    {
        var client = new MongoClient(settings.ConnectionString);
        var database = client.GetDatabase(settings.DatabaseName);
        
        _collection = database.GetCollection<Entities.Category>(settings.CategoryCollectionName);
        _mapper = mapper;
    }

    public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
    {
        var values = await _collection.Find(x => true).ToListAsync();
        return _mapper.Map<List<ResultCategoryDto>>(values);
    }

    public async Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
    {
        
        var value = _mapper.Map<Entities.Category>(createCategoryDto);
        await _collection.InsertOneAsync(value);
    }

    public async Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
    {
        var values = _mapper.Map<Entities.Category>(updateCategoryDto);
        await _collection.FindOneAndReplaceAsync(x => x.Id == values.Id, values);
    }

    public async Task DeleteCategoryAsync(string id)
    {
        await _collection.DeleteOneAsync(x => x.Id == id);
    }

    public async Task<GetByIdCategoryDto> GetByIdCategoryAsync(string id)
    {
        var values = await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();
        return _mapper.Map<GetByIdCategoryDto>(values);
    }
}