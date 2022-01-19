using System.Collections.Generic;
using System.Threading.Tasks;
using Dream_house.Models;
using Dream_house.Repositories.GenericRepository;

namespace Dream_house.Repositories.DatabaseRepository
{
    public interface IDatabaseRepository: IGenericRepository<Home>
    {
        Home GetByName(string name);
        Home GetByNameIncludingRoom(string name);
        Task<Home> GetByNameAsync(string name);

        List<Home> GetAllWithInclude();
        Task<List<Home>> GetAllWithIncludeAsync();

        List<Home> GetAllWithJoin();
    }
}
