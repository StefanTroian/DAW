using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dream_house.Models;
using Dream_house.Repositories.GenericRepository;

namespace Dream_house.Repositories.UserRepository
{
    public interface IUserRepository: IGenericRepository<User>
    {
        User GetByUsername(string username);
        //Task<User> CreateUser(User user);
        User GetUserWithHouseJoin(Guid id);
    }
}
