using KayraExport.Domain.Entities;

namespace KayraExport.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<Product?> GetByIdAsync(int id);
        Task<IReadOnlyList<Product>> GetAllAsync();
        Task AddAsync(Product product);
        void Delete(Product product);
    }
}