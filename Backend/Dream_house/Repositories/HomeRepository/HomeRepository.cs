using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dream_house.Data;
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
    }
}
