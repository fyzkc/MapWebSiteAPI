using HaritaUygulamasi.Data;
using HaritaUygulamasi.Interfaces;
using Npgsql;

namespace HaritaUygulamasi.Services
{
    public class PostgreService : IPostgreService
    {
        public static string connectionString = "server=localHost; port=5432; Database=dbCoordinates; user Id=postgres; password=33992562";
        NpgsqlDataReader? dataReader;
        NpgsqlConnection connection = new NpgsqlConnection(connectionString);
        public Response SelectAll(string tableName)
        {
            List<Coordinate> coordinatesList = new List<Coordinate>();
            Coordinate c = new Coordinate();
            var result = new Response();
            string query = $"SELECT * FROM \"{tableName}\"";

            NpgsqlCommand command = new NpgsqlCommand(query, connection);

            try
            {
                connection.Open();

                dataReader = command.ExecuteReader();

                if (!dataReader.Read())
                {
                    result.Message = "There is no coordinate in database";
                    return result;
                }
                while (dataReader.Read())
                {
                    c.Id = dataReader.GetInt32(0);
                    c.CoordinateX = dataReader.GetDouble(1);
                    c.CoordinateY = dataReader.GetDouble(2);
                    c.PlaceName = dataReader.GetString(3);

                    coordinatesList.Add(c);
                }

                dataReader.Close();
                connection.Close();

                result.IsSuccess = true;
                result.Message = "Coordinates are listed succesfully!";
                result.Data = coordinatesList;

                return result;
            }
            catch (Exception)
            {
                result.Message = "Something went wrong";
                return result;
            }
        }

        public Response Insert(Coordinate c, string tableName, string columnName)
        {
            throw new NotImplementedException();
        }

        public Response Update(Coordinate coordinate, int id)
        {
            throw new NotImplementedException();
        }

        public Response Delete(int id)
        {
            throw new NotImplementedException();
        }


        public Response Select(string tableName, string columnName, int columnValue)
        {
            throw new NotImplementedException();
        }
    }
}
