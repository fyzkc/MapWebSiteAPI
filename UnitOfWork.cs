using HaritaUygulamasi.Data;
using HaritaUygulamasi.Interfaces;
using HaritaUygulamasi.Repository;

namespace HaritaUygulamasi
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }
        public IRepository<T> GetRepository<T>() where T : class
        {
            return new Repository<T>(_context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        
    }
}
