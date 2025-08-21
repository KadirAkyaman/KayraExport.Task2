using KayraExport.Domain.Interfaces;
using KayraExport.Infrastructure.Persistence.Repositories;

namespace KayraExport.Infrastructure.Persistence.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public IProductRepository ProductRepository { get; }
        public IUserRepository UserRepository { get; }

        public UnitOfWork(AppDbContext appDbContext)
        {
            _context = appDbContext;

            ProductRepository = new ProductRepository(_context);
            UserRepository = new UserRepository(_context);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}