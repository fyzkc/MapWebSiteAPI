using HaritaUygulamasi.Data;
using HaritaUygulamasi.Interfaces;
using HaritaUygulamasi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HaritaUygulamasi.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class CoordinateController : ControllerBase
    {
        private readonly ICoordinateService coordinateService;
        public CoordinateController(ICoordinateService cService)
        {
            this.coordinateService = new CoordinateService();
            coordinateService = cService;
        }

        [HttpGet]
        public Response Get()
        {
            return coordinateService.Get();
        }

        [HttpGet]
        public Response GetById(int searchedId)
        {
            return coordinateService.GetById(searchedId);
        }

        [HttpPost]
        public Response Add(Coordinate k)
        {
            return coordinateService.Add(k);
        }

        [HttpPut]
        public Response Update(Coordinate coordinate, int id)
        {
            return coordinateService.Update(coordinate, id);
        }

        [HttpDelete]
        public Response Delete(int id)
        {
            return coordinateService.Delete(id);
        }
    }
}
