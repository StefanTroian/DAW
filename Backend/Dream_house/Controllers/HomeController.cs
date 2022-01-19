using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dream_house.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        public static List<Home> homes = new List<Home>
        {
            new Home { Name = "House1", Type="Apartament"},
            new Home { Name = "House2", Type="Vila"}
        };

        // GET
        [HttpGet("")]
        public IEnumerable<Home> GetHomes()
        {
            return homes;
        }

        [HttpGet("byId")]
        public Home GetHomesById(int id)
        {
            return homes.FirstOrDefault(home => home.Id.Equals(id));
        }

        [HttpGet("byId/{id}")]
        public Home GetHomesByIdInEndpoint(int id)
        {
            return homes.FirstOrDefault(home => home.Id.Equals(id));
        }

        [HttpGet("filters/{name}/{type}")]
        public Home GetHomesWithFilters(string name, string type)
        {
            return homes.FirstOrDefault(home => home.Name.Equals(name) && home.Type.Equals(type));
        }

        [HttpGet("fromHeader")]
        public Home GetHomeByIdFromHeader([FromHeader] int id)
        {
            return homes.FirstOrDefault(home => home.Id.Equals(id));
        }

        [HttpGet("fromQuery")]
        public Home GetHomeByIdFromQuery([FromQuery] int id)
        {
            return homes.FirstOrDefault(home => home.Id.Equals(id));
        }



        // POST
        [HttpPost]
        public IActionResult Add(Home home)
        {
            homes.Add(home);
            return Ok(homes);
        }

        [HttpPost("fromBody")]
        public IActionResult AddWithBody([FromBody] Home home)
        {
            homes.Add(home);
            return Ok(homes);
        }



        // UPDATE
        public IActionResult Update([FromBody] Home home)
        {
            var homeIndex = homes.FindIndex((Home _home) => _home.Id.Equals(home.Id));
            homes[homeIndex] = home;

            return Ok(homes);
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
            homes.Remove(home);
            return Ok(homes);
        }

    }
}
