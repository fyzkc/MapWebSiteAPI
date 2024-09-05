using HaritaUygulamasi.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HaritaUygulamasi.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class PostgreController : ControllerBase
    {
        private readonly IPostgreService postgreService;
        public PostgreController(IPostgreService pService)
        {
            postgreService = pService;
        }



        [HttpGet]
        public Response SelectAll(string tableName)
        {
            return postgreService.SelectAll(tableName);
        }
    }
}
