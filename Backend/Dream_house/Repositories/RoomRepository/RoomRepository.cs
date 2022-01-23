using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dream_house.Data;
using Dream_house.Models;
using Dream_house.Repositories.GenericRepository;

namespace Dream_house.Repositories.RoomRepository
{
    public class RoomRepository: GenericRepository<Room>, IRoomRepository
    {
        public RoomRepository(DreamHouseContext context) : base(context)
        {

        }
    }
}
