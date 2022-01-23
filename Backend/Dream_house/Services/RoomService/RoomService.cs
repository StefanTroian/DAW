using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dream_house.Models;
using Dream_house.Repositories.RoomRepository;

namespace Dream_house.Services.RoomService
{
    public class RoomService : IRoomService
    {
        public IRoomRepository _roomRepository;

        public RoomService(IRoomRepository roomReporistory)
        {
            _roomRepository = roomReporistory;
        }

        public IEnumerable<Room> GetAllRooms()
        {
            return (IEnumerable<Room>)_roomRepository.GetAll();
        }

        public Room GetRoomById(Guid id)
        {
            return _roomRepository.FindById(id);
        }

        public void CreateRoom(Room room)
        {
            _roomRepository.Create(room);
            _roomRepository.Save();
        }

        public void UpdateRoom(Room room)
        {
            _roomRepository.Update(room);
            _roomRepository.Save();
        }

        public void DeleteRoom(Room room)
        {
            _roomRepository.Delete(room);
            _roomRepository.Save();
        }
    }
}
