using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dream_house.Data;
using Dream_house.Models;
using Dream_house.Repositories.GenericRepository;

namespace Dream_house.Repositories.UserRepository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(DreamHouseContext context) : base(context)
        {

        }

        public User GetByUsername(string username)
        {
            return _table.FirstOrDefault(x => x.Username.ToLower().Equals(username.ToLower()));
        }
        //public Task<User> CreateUser(User user)
        //{
        //    throw new NotImplementedException();
        //}

        public User GetUserWithHouseJoin(Guid id)
        {
            var result = _table.Join(_context.Home, user => user.Id, home => home.UserId,
                (user, home) => new { user, home }).Select(obj => obj.user).FirstOrDefault(x => x.Id.Equals(id));

            return result;
        }

    }
}
