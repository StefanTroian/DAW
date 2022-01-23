using System;
using Dream_house.Models;
using Dream_house.Services.RoomService;
using Microsoft.AspNetCore.Mvc;

namespace Dream_house.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }


        // GET
        [HttpGet("")]
        public IActionResult GetRooms()
        {
            var rooms = _roomService.GetAllRooms();
            return Ok(rooms);
        }

        [HttpGet("byId")]
        public IActionResult GetRoomsById(Guid id)
        {
            var room = _roomService.GetRoomById(id);
            return Ok(room);
        }

        [HttpGet("byId/{id}")]
        public IActionResult GetRoomsByIdInEndpoint(Guid id)
        {
            var room = _roomService.GetRoomById(id);
            return Ok(room);
        }

        [HttpGet("fromHeader")]
        public IActionResult GetRoomByIdFromHeader([FromHeader] Guid id)
        {
            var room = _roomService.GetRoomById(id);
            return Ok(room);
        }

        [HttpGet("fromQuery")]
        public IActionResult GetRoomByIdFromQuery([FromQuery] Guid id)
        {
            var room = _roomService.GetRoomById(id);
            return Ok(room);
        }



        // POST
        [HttpPost("create")]
        public IActionResult Add([FromBody] Room room)
        {
            _roomService.CreateRoom(room);
            return Ok();
        }



        // UPDATE
        public IActionResult Update([FromBody] Room room)
        {
            _roomService.UpdateRoom(room);
            return Ok();
        }




        // DELETE
        [HttpDelete]
        public IActionResult Delete(Room room)
        {
            _roomService.DeleteRoom(room);
            return Ok();
        }
    }
}
