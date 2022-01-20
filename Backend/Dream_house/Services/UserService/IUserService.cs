using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dream_house.DTOs;
using Dream_house.Models;

namespace Dream_house.Services.UserService
{
    public interface IUserService
    {
        UserResponseDTO Auth(UserRequestDTO model);
        IEnumerable<User> GetAllUsers();
        User GetById(Guid id);
    }
}
