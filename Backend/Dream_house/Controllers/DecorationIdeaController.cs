using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dream_house.Models;
using Dream_house.Services.DecorationIdeaService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dream_house.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DecorationIdeaController : ControllerBase
    {
        private IDecorationIdeaService _decorationIdeaService;

        public DecorationIdeaController(IDecorationIdeaService decorationIdeaService)
        {
            _decorationIdeaService = decorationIdeaService;
        }


        // GET
        [HttpGet("")]
        public IActionResult GetDecorationIdeas()
        {
            var decorationIdeas = _decorationIdeaService.GetAllDecorationIdeas();
            return Ok(decorationIdeas);
        }

        [HttpGet("byId")]
        public IActionResult GetDecorationIdeayId(Guid id)
        {
            var decorationIdea = _decorationIdeaService.GetDecorationIdeaById(id);
            return Ok(decorationIdea);
        }

        [HttpGet("byId/{id}")]
        public IActionResult GetDecorationIdeaByIdInEndpoint(Guid id)
        {
            var decorationIdea = _decorationIdeaService.GetDecorationIdeaById(id);
            return Ok(decorationIdea);
        }

        [HttpGet("fromHeader")]
        public IActionResult GetDecorationIdeaByIdFromHeader([FromHeader] Guid id)
        {
            var decorationIdea = _decorationIdeaService.GetDecorationIdeaById(id);
            return Ok(decorationIdea);
        }

        [HttpGet("fromQuery")]
        public IActionResult GetDecorationIdeaByIdFromQuery([FromQuery] Guid id)
        {
            var decorationIdea = _decorationIdeaService.GetDecorationIdeaById(id);
            return Ok(decorationIdea);
        }



        // POST
        [HttpPost("create")]
        public IActionResult Add([FromBody] DecorationIdea room)
        {
            _decorationIdeaService.CreateDecorationIdea(room);
            return Ok();
        }



        // UPDATE
        public IActionResult Update([FromBody] DecorationIdea room)
        {
            _decorationIdeaService.UpdateDecorationIdea(room);
            return Ok();
        }




        // DELETE
        [HttpDelete]
        public IActionResult Delete(DecorationIdea room)
        {
            _decorationIdeaService.DeleteDecorationIdea(room);
            return Ok();
        }
    }
}
