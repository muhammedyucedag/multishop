using multishop.Catalog.Dtos.Product;

namespace multishop.Catalog.Services.Product;

public interface IProductService
{
    Task<List<ResultProductDto>> GetAllProductAsync();
    Task CreateProductAsync(CreateProductDto createProductDto);
    Task UpdateProductAsync(UpdateProductDto updateProductDto);
    Task DeleteProductAsync(string id);
    Task<GetByIdProductDto> GetByIdProductAsync(string id);
}