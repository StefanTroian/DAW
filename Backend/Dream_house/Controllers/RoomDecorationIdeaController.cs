using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dream_house.Models;
using Dream_house.Services.RoomDecorationIdeaService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dream_house.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomDecorationIdeaController : ControllerBase
    {
        private IRoomDecorationIdeaService _roomDecorationIdeaService;

        public RoomDecorationIdeaController(IRoomDecorationIdeaService roomDecorationIdeaService)
        {
            _roomDecorationIdeaService = roomDecorationIdeaService;
        }


        // GET
        [HttpGet("")]
        public IActionResult GetRoomDecorationIdeas()
        {
            var homes = _roomDecorationIdeaService.GetAllRoomDecorationIdeas();
            return Ok(homes);
        }

        [HttpGet("byId")]
        public IActionResult GetRoomDecorationIdeaById(Guid id)
        {
            var home = _roomDecorationIdeaService.GetRoomDecorationIdeaById(id);
            return Ok(home);
        }

        [HttpGet("byId/{id}")]
        public IActionResult GetRoomDecorationIdeaByIdInEndpoint(Guid id)
        {
            var home = _roomDecorationIdeaService.GetRoomDecorationIdeaById(id);
            return Ok(home);
        }

        [HttpGet("fromHeader")]
        public IActionResult GetRoomDecorationIdeaByIdFromHeader([FromHeader] Guid id)
        {
            var home = _roomDecorationIdeaService.GetRoomDecorationIdeaById(id);
            return Ok(home);
        }

        [HttpGet("fromQuery")]
        public IActionResult GetRoomDecorationIdeaByIdFromQuery([FromQuery] Guid id)
        {
            var home = _roomDecorationIdeaService.GetRoomDecorationIdeaById(id);
            return Ok(home);
        }



        // POST
        [HttpPost("create")]
        public IActionResult Add([FromBody] Room_DecorationIdea room_DecorationIdea)
        {
            _roomDecorationIdeaService.CreateRoomDecorationIdea(room_DecorationIdea);
            return Ok();
        }



        // UPDATE
        public IActionResult Update([FromBody] Room_DecorationIdea room_DecorationIdea)
        {
            _roomDecorationIdeaService.UpdateRoomDecorationIdea(room_DecorationIdea);
            return Ok();
        }




        // DELETE
        [HttpDelete]
        public IActionResult Delete(Room_DecorationIdea room_DecorationIdea)
        {
            _roomDecorationIdeaService.DeleteRoomDecorationIdea(room_DecorationIdea);
            return Ok();
        }
    }
}
