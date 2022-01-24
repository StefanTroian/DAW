using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dream_house.Models;
using Dream_house.Repositories.RoomDecorationIdeaRepository;

namespace Dream_house.Services.RoomDecorationIdeaService
{
    public class RoomDecorationIdeaService : IRoomDecorationIdeaService
    {
        public IRoomDecorationIdeaRepository _roomDecorationIdeaRepository;

        public RoomDecorationIdeaService(IRoomDecorationIdeaRepository roomDecorationIdeaRepository)
        {
            _roomDecorationIdeaRepository = roomDecorationIdeaRepository;
        }

        public IEnumerable<Room_DecorationIdea> GetAllRoomDecorationIdeas()
        {
            return (IEnumerable<Room_DecorationIdea>)_roomDecorationIdeaRepository.GetAll();
        }

        public Room_DecorationIdea GetRoomDecorationIdeaById(Guid id)
        {
            return _roomDecorationIdeaRepository.FindById(id);
        }

        public void CreateRoomDecorationIdea(Room_DecorationIdea room_DecorationIdea)
        {
            _roomDecorationIdeaRepository.Create(room_DecorationIdea);
            _roomDecorationIdeaRepository.Save();
        }

        public void UpdateRoomDecorationIdea(Room_DecorationIdea room_DecorationIdea)
        {
            _roomDecorationIdeaRepository.Update(room_DecorationIdea);
            _roomDecorationIdeaRepository.Save();
        }

        public void DeleteRoomDecorationIdea(Room_DecorationIdea room_DecorationIdea)
        {
            _roomDecorationIdeaRepository.Delete(room_DecorationIdea);
            _roomDecorationIdeaRepository.Save();
        }
    }
}
