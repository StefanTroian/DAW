using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dream_house.Data;
using Dream_house.DTOs;
using Dream_house.Models;
using Dream_house.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace Dream_house.Repositories.HomeRepository
{
    public class HomeRepository: GenericRepository<Home>, IHomeRepository
    {
        public HomeRepository(DreamHouseContext context) : base(context)
        {

        }

        public Home GetByNameIncludingRoom(string name)
        {
            return _table.Include(x => x.Rooms).FirstOrDefault(x => x.Name.ToLower().Equals(name.ToLower()));
        }

        public HomeRoomDTO GetHomeByIdWithJoin(Guid id)
        {
            var result = _table.Join(_context.Room, home => home.Id, room => room.Home_id,
                (home, room) => new { home, room }).Select(obj => obj).FirstOrDefault(x => x.home.Id.Equals(id));
            //var result = _table.Where(h => h.Id == id).SelectMany(h => h.Rooms); 
            
            HomeRoomDTO res = new HomeRoomDTO()
            {
                home = result.home,
                room = result.room
            };

            return res;
        }

        public List<HomeByTypeDTO> GetHomeGroupByType()
        {
            List<HomeByTypeDTO> result = new List<HomeByTypeDTO>();
        
            var groupedhomes = _table.AsEnumerable().GroupBy(h => h.Type);

            foreach (var homegroupbytype in groupedhomes)
            {
                HomeByTypeDTO localRes = new HomeByTypeDTO()
                {
                    Type = homegroupbytype.Key,
                    Home = homegroupbytype.ToList<Home>()
                };

                result.Add(localRes);
            }

            return result; 
        }

        public HomeByTypeDTO GetHomeWhereType(string type)
        {
            var homes = _table.Where(h => h.Type == type).ToList();

            HomeByTypeDTO result = new HomeByTypeDTO()
            {
                Type = type,
                Home = homes
            };

            return result;
        }
    }
}
