using KayraExport.Domain.DTOs;

namespace KayraExport.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllProductsAsync();
        Task<ProductDto?> GetProductByIdAsync(int id);
        Task AddProductAsync(CreateProductDto productDto);
        Task UpdateProductAsync(int id, UpdateProductDto productDto);
        Task DeleteProductAsync(int id);
    }
}