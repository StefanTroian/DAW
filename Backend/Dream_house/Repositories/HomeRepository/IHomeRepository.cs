using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dream_house.DTOs;
using Dream_house.Models;
using Dream_house.Repositories.GenericRepository;

namespace Dream_house.Repositories.HomeRepository
{
    public interface IHomeRepository: IGenericRepository<Home>
    {
        Home GetByNameIncludingRoom(string name);
        Home GetHomeByIdWithJoin(Guid id);
        List<HomeByTypeDTO> GetHomeGroupByType();
        HomeByTypeDTO GetHomeWhereType(string type);
    }
}
