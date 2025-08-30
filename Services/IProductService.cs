using LibraryManagementAPI.DTOs;

namespace LibraryManagementAPI.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetProductsAsync(ProductSearchDto searchDto);
        Task<ProductDto?> GetProductByIdAsync(int id);
        Task<ProductDto?> CreateProductAsync(CreateProductDto createProductDto);
        Task<ProductDto?> UpdateProductAsync(int id, UpdateProductDto updateProductDto);
        Task<bool> DeleteProductAsync(int id);
        Task<IEnumerable<ProductDto>> GetFeaturedProductsAsync(int count = 10);
        Task<IEnumerable<ProductDto>> GetNewReleasesAsync(int count = 10);
        Task<IEnumerable<ProductDto>> GetProductsByCategoryAsync(int categoryId, int count = 10);
        Task<IEnumerable<ProductDto>> GetProductsByAuthorAsync(int authorId, int count = 10);
        Task<IEnumerable<ProductDto>> GetProductsByPublisherAsync(int publisherId, int count = 10);
        Task<bool> UpdateProductStockAsync(int id, int quantity);
        Task<IEnumerable<ProductImageDto>> GetProductImagesAsync(int id);
        Task<ProductImageDto?> AddProductImageAsync(CreateProductImageDto createImageDto);
        Task IncrementViewCountAsync(int id);
    }
}
