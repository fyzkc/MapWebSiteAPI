namespace HaritaUygulamasi.Interfaces
{
    public interface IEntityService<T> where T : class
    {
        Response GetAll();
        Response GetById(int id);
        Response Add(T entity);
        Response Update(T entity);
        Response Delete(int id);
    }
}
