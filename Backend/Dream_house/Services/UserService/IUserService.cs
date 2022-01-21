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
        User GetUserById(Guid id);
        User GetUserAndHome(Guid id);
        void CreateUser(User user);
        void UpdateUser(User user);
        void DeleteUser(User user);
    }
}
