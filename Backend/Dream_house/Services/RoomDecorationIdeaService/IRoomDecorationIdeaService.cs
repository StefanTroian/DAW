using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dream_house.Models;

namespace Dream_house.Services.RoomDecorationIdeaService
{
    public interface IRoomDecorationIdeaService
    {
        IEnumerable<Room_DecorationIdea> GetAllRoomDecorationIdeas();
        Room_DecorationIdea GetRoomDecorationIdeaById(Guid id);
        void CreateRoomDecorationIdea(Room_DecorationIdea room_DecorationIdea);
        void UpdateRoomDecorationIdea(Room_DecorationIdea room_DecorationIdea);
        void DeleteRoomDecorationIdea(Room_DecorationIdea room_DecorationIdea);
    }
}
