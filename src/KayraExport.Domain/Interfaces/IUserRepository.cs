using KayraExport.Domain.Entities;

namespace KayraExport.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetByIdAsync(int id);
        Task<User?> GetByEmailAsync(string email);
        Task AddAsync(User user);
        void Delete(User user);
    }
}