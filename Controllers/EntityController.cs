using HaritaUygulamasi.Data;
using HaritaUygulamasi.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HaritaUygulamasi.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class EntityController : ControllerBase
    {
        private readonly IEntityService<Coordinate> _coordinateService;

        public EntityController(IEntityService<Coordinate> cService)
        {
            _coordinateService = cService;
        }

        [HttpGet]
        public Response GetAll()
        {
            return _coordinateService.GetAll();
        }

        [HttpGet]
        public Response GetById(int id)
        {
            return _coordinateService.GetById(id);
        }

        [HttpPost]
        public Response Add(Coordinate coordinate)
        {
            return _coordinateService.Add(coordinate);
        }

        [HttpPut]
        public Response Update(int id, Coordinate coordinate)
        {
            if (id != coordinate.Id)
            {
                return new Response
                {
                    Message = "ID mismatch"
                };
            }
            return _coordinateService.Update(coordinate);
        }

        [HttpDelete]
        public Response Delete(int id)
        {
            return _coordinateService.Delete(id);
        }
    }
}
