using HaritaUygulamasi.Data;

namespace HaritaUygulamasi.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<T> GetRepository<T>() where T : class;
        int Complete();
    }
}
