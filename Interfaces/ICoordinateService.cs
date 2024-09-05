using HaritaUygulamasi.Data;

namespace HaritaUygulamasi.Interfaces
{
    public interface ICoordinateService
    {
        Response Get();
        Response GetById(int id);
        Response Add(Coordinate k);
        Response Update(Coordinate k, int id);
        Response Delete(int id);
    }
}
