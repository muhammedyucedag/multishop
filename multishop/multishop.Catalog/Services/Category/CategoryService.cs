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

    public Task<List<ResultCategoryDto>> GetAllCategoryAsync()
    {
        throw new NotImplementedException();
    }

    public Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
    {
        
        var value = _mapper.Map<Entities.Category>(createCategoryDto);
        //await
        throw new NotImplementedException();

    }

    public Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
    {
        throw new NotImplementedException();
    }

    public Task DeleteCategoryAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task<GetByIdCategoryDto> GetByIdCategoryAsync(string id)
    {
        throw new NotImplementedException();
    }
}