using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dream_house.DTOs;
using Dream_house.Models;
using Dream_house.Repositories.HomeRepository;

namespace Dream_house.Services.HomeService
{
    public class HomeService: IHomeService
    {
        public IHomeRepository _homeRepository;

        public HomeService(IHomeRepository homeRepository)
        {
            _homeRepository = homeRepository;
        }

        public IEnumerable<Home> GetAllHomes()
        {
            return (IEnumerable<Home>)_homeRepository.GetAll();
        }

        public Home GetHomeById(Guid id)
        {
            return _homeRepository.FindById(id);
        }

        public void CreateHome(Home home)
        {
            _homeRepository.Create(home);
            _homeRepository.Save();
        }

        public void UpdateHome(Home home)
        {
            _homeRepository.Update(home);
            _homeRepository.Save();
        }
        public void DeleteHome(Home home)
        {
            _homeRepository.Delete(home);
            _homeRepository.Save();
        }

        public HomeRoomResultDTO GetDataMappedByName(string name)
        {
            Home home = _homeRepository.GetByNameIncludingRoom(name);

            HomeRoomResultDTO result = new HomeRoomResultDTO
            {
                Name = home.Name,
                Type = home.Type,
                HomeId = home.Id,
                Rooms = home.Rooms.ToList<Room>()
            };

            return result;
        }

        public HomeRoomDTO GetHomeByIdWithJoinRooms(Guid id)
        {
            HomeRoomDTO homeRoom = _homeRepository.GetHomeByIdWithJoin(id);

            //HomeRoomResultDTO result = new HomeRoomResultDTO()
            //{
            //    Name = homeRoom.home.Name,
            //    Type = homeRoom.home.Type,
            //    HomeId = homeRoom.Id,
            //    Rooms = home.Rooms.ToList<Room>()
            //};

            return homeRoom;
        }

        public List<HomeByTypeDTO> GetHomeGroupByType()
        {
            var homes = _homeRepository.GetHomeGroupByType();

            return homes;
        }

        public HomeByTypeDTO GetHomeWhereType(string type)
        {
            var homes = _homeRepository.GetHomeWhereType(type);

            return homes;
        }
    }
}
