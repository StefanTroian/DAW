using System;
using Dream_house.Models;
using Dream_house.Services.HomeService;
using Microsoft.AspNetCore.Mvc;

namespace Dream_house.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private IHomeService _homeService;

        public HomeController(IHomeService homeService)
        {
            _homeService = homeService;
        }


        // GET
        [HttpGet("")]
        public IActionResult GetHomes()
        {
            var homes = _homeService.GetAllHomes();
            return Ok(homes);
        }

        [HttpGet("byId")]
        public IActionResult GetHomesById(Guid id)
        {
            var home = _homeService.GetHomeById(id);
            return Ok(home);
        }

        [HttpGet("byId/{id}")]
        public IActionResult GetHomesByIdInEndpoint(Guid id)
        {
            var home = _homeService.GetHomeById(id);
            return Ok(home);
        }

        [HttpGet("fromHeader")]
        public IActionResult GetHomeByIdFromHeader([FromHeader] Guid id)
        {
            var home = _homeService.GetHomeById(id);
            return Ok(home);
        }

        [HttpGet("fromQuery")]
        public IActionResult GetHomeByIdFromQuery([FromQuery] Guid id)
        {
            var home = _homeService.GetHomeById(id);
            return Ok(home);
        }



        // POST
        [HttpPost("create")]
        public IActionResult Add([FromBody] Home home)
        {
            _homeService.CreateHome(home);
            return Ok();
        }



        // UPDATE
        public IActionResult Update([FromBody] Home home)
        {
            _homeService.UpdateHome(home);
            return Ok();
        }




        // DELETE
        [HttpDelete]
        public IActionResult Delete(Home home)
        {
            _homeService.DeleteHome(home);
            return Ok();
        }



        // INCLUDE
        [HttpGet("byName/{name}")]
        public IActionResult GetByName(string name)
        {
            var result = _homeService.GetDataMappedByName(name);
            return Ok(result);
        }



        // JOIN
        [HttpGet("byIdJoin/{id}")]
        public IActionResult GetByIdJoin(Guid id)
        {
            var result = _homeService.GetHomeByIdWithJoinRooms(id);
            return Ok(result);
        }



        // GROUP BY
        [HttpGet("byType")]
        public IActionResult GetHomeGroupByType()
        {
            var result = _homeService.GetHomeGroupByType();
            return Ok(result);
        }



        // WHERE
        [HttpGet("byType/{type}")]
        public IActionResult GetHomeGroupByType(string type)
        {
            var result = _homeService.GetHomeWhereType(type);
            return Ok(result);
        }
    }
}
