using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dream_house.Models;
using Dream_house.Services.HomeService;
using Microsoft.AspNetCore.Http;
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

        //[HttpGet("filters/{name}/{type}")]
        //public Home GetHomesWithFilters(string name, string type)
        //{
        //    return homes.FirstOrDefault(home => home.Name.Equals(name) && home.Type.Equals(type));
        //}

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

        //[HttpPost("fromBody")]
        //public IActionResult AddWithBody([FromBody] Home home)
        //{
        //    homes.Add(home);
        //    return Ok(homes);
        //}



        // UPDATE
        public IActionResult Update([FromBody] Home home)
        {
            _homeService.UpdateHome(home);
            return Ok();
        }

        //public async Task<IActionResult> UpdateAsync([FromBody] Home home)
        //{
        //    var homeIndex = homes.FindIndex((Home _home) => _home.Id.Equals(home.Id));
        //    homes[homeIndex] = home;

        //    return Ok(homes);
        //}



        // DELETE
        [HttpDelete]
        public IActionResult Delete(Home home)
        {
            _homeService.DeleteHome(home);
            return Ok();
        }

    }
}
