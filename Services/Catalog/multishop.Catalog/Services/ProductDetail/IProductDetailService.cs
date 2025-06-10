using multishop.Catalog.Dtos.ProductDetail;

namespace multishop.Catalog.Services.ProductDetail;

public interface IProductDetailService
{
    Task<List<ResultProductDetailDto>> GetAllProductDetailAsync();
    Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto);
    Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto);
    Task DeleteProductDetailAsync(string id);
    Task<GetByIdProductDetailDto> GetByIdProductDetailAsync(string id);
}