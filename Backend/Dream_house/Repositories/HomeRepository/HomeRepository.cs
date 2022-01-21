using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dream_house.Data;
using Dream_house.Models;
using Dream_house.Repositories.GenericRepository;

namespace Dream_house.Repositories.HomeRepository
{
    public class HomeRepository: GenericRepository<Home>, IHomeRepository
    {
        public HomeRepository(DreamHouseContext context) : base(context)
        {

        }
    }
}
