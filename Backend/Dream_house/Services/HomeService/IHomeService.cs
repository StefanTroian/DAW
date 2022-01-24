using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dream_house.DTOs;
using Dream_house.Models;

namespace Dream_house.Services.HomeService
{
    public interface IHomeService
    {
        IEnumerable<Home> GetAllHomes();
        Home GetHomeById(Guid id);
        void CreateHome(Home home);
        void UpdateHome(Home home);
        void DeleteHome(Home home);
        HomeRoomResultDTO GetDataMappedByName(string name);
        HomeRoomResultDTO GetHomeByIdWithJoinRooms(Guid id);
        List<HomeByTypeDTO> GetHomeGroupByType();
        HomeByTypeDTO GetHomeWhereType(string type);
    }
}
