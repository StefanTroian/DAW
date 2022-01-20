using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dream_house.Services.DemoService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dream_house.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoController : ControllerBase
    {
        private readonly IDemoService _demoService;
        
        public DemoController(IDemoService demoService)
        {
            _demoService = demoService;
        }

        [HttpGet("byName/{name}")]
        public IActionResult GetByName(string name)
        {
            var result = _demoService.GetDataMappedByName(name);
            return Ok(result);
        }
    }
}
