using HaritaUygulamasi.Data;

namespace HaritaUygulamasi.Interfaces
{
    public interface IPostgreService
    {
        Response SelectAll(string tableName);
        Response Select(string tableName, string columnName, int columnValue);
        Response Insert(Coordinate c, string tableName, string columnName);
        Response Update(Coordinate coordinate, int id);
        Response Delete(int id);
    }
}
