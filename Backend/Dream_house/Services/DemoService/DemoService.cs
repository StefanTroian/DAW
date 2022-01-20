using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dream_house.DTOs;
using Dream_house.Models;
using Dream_house.Repositories.DatabaseRepository;

namespace Dream_house.Services.DemoService
{
    public class DemoService: IDemoService
    {
        public IDatabaseRepository _databaseRepository;

        public DemoService(IDatabaseRepository databaseRepository)
        {
            _databaseRepository = databaseRepository;
        }

        public HomeRoomResultDTO GetDataMappedByName(string name)
        {
            Home home = _databaseRepository.GetByNameIncludingRoom(name);

            HomeRoomResultDTO result = new HomeRoomResultDTO
            {
                Name = home.Name,
                Type = home.Type,
                HomeId = home.Id,
                Rooms = home.Rooms.ToList<Room>()
            };

            return result;
        }
    }
}
