using HaritaUygulamasi.Data;
using HaritaUygulamasi.Interfaces;

namespace HaritaUygulamasi.Services
{
    public class CoordinateService : ICoordinateService
    {
        public static readonly List<Coordinate> coordinatesList = new List<Coordinate>();
        public Response Get()
        {
            var result = new Response();
            try
            {
                if (coordinatesList.Count == 0)
                {
                    result.Message = "The are no coordinates in the list";
                    return result;
                }
                result.Data = coordinatesList;
                result.IsSuccess = true;
                result.Message = "The coordinates are listed succesfully";
            }
            catch (Exception)
            {
                result.Message = "Something went wrong";
                return result;
            }

            return result;
        }
        public Response GetById(int searchedId)
        {

            var result = new Response();
            try
            {
                var coordinate = coordinatesList.Find(k => k.Id == searchedId);
                if (coordinate == null)
                {
                    result.Message = "There is no coordinate indicated by this ID";
                    return result;
                }
                result.Data = coordinate;
                result.IsSuccess = true;
                result.Message = "The coordinate indicated by this ID has been listed";
            }
            catch (Exception)
            {
                result.Message = "Something went wrong";
                return result;
            }

            return result;
        }
        public Response Add(Coordinate k)
        {
            var result = new Response();
            var pin = new Coordinate();
            try
            {
                pin.Id = k.Id;
                pin.CoordinateX = k.CoordinateX;
                pin.CoordinateY = k.CoordinateY;
                pin.PlaceName = k.PlaceName;

                coordinatesList.Add(pin);

                result.Data = pin;
                result.IsSuccess = true;
                result.Message = "The coordinate added succesfully";
            }
            catch (Exception)
            {
                result.Message = "Something went wrong";
                return result;
            }
            return result;
        }

        public Response Update(Coordinate coordinate, int id)
        {
            var result = new Response();
            try
            {
                var editedCoordinate = coordinatesList.Find(k => k.Id == id);
                if (editedCoordinate == null)
                {
                    result.Message = "There is no coordinate indicated by this ID";
                    return result;
                }

                editedCoordinate.CoordinateX = coordinate.CoordinateX;
                editedCoordinate.CoordinateY = coordinate.CoordinateY;
                editedCoordinate.PlaceName = coordinate.PlaceName;

                result.Data = editedCoordinate;
                result.IsSuccess = true;
                result.Message = "The coordinate updated succesfully";

            }
            catch (Exception)
            {
                result.Message = "Something went wrong";
                return result;
            }
            return result;
        }

        public Response Delete(int id)
        {
            var result = new Response();
            try
            {
                var deleted = coordinatesList.Find(k => k.Id == id);
                if (deleted == null)
                {
                    result.Message = "There is no coordinate indicated by this ID";
                    return result;
                }

                coordinatesList.Remove(deleted);

                result.Data = deleted;
                result.IsSuccess = true;
                result.Message = "The coordinate deleted succesfully";

            }
            catch (Exception)
            {
                result.Message = "Something went wrong";
                return result;
            }

            return result;
        }
    }
}
