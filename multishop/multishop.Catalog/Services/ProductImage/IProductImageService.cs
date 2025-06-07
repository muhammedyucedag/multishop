﻿using multishop.Catalog.Dtos.ProductImage;

namespace multishop.Catalog.Services.ProductImage;

public interface IProductImageService
{
    Task<List<ResultProductImageDto>> GetAllProductImageAsync();
    Task CreateProductImageAsync(CreateProductImageDto createProductImageDto);
    Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto);
    Task DeleteProductImageAsync(string id);
    Task<GetByIdProductImageDto> GetByIdProductImageAsync(string id);
}