using multishop.Catalog.Dtos.Category;

namespace multishop.Catalog.Services.Category;

public interface ICategoryService
{
    Task<List<ResultCategoryDto>> GetAllCategoryAsync();
    Task CreateCategoryAsync(CreateCategoryDto createCategoryDto);
    Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto);
    Task DeleteCategoryAsync(string id);
    Task<GetByIdCategoryDto> GetByIdCategoryAsync(string id);
}