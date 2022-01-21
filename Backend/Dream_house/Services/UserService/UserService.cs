using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BCryptNet = BCrypt.Net.BCrypt;
using Dream_house.Data;
using Dream_house.DTOs;
using Dream_house.Models;
using Dream_house.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Dream_house.Repositories.UserRepository;

namespace Dream_house.Services.UserService
{
    public class UserService : IUserService
    {
        public DreamHouseContext _DreamHouseContext;
        private IJWTUtils _iJWTUtils;
        private readonly AppSettings _appSettings;
        public IUserRepository _userRepository;

        public UserService(DreamHouseContext DreamHouseContext, IJWTUtils iJWTUtils, IOptions<AppSettings> appSettings, IUserRepository userRepository)
        {
            _DreamHouseContext = DreamHouseContext;
            _iJWTUtils = iJWTUtils;
            _appSettings = appSettings.Value;
            _userRepository = userRepository;
        }

        public UserResponseDTO Auth(UserRequestDTO model)
        {
            var user = _DreamHouseContext.User.FirstOrDefault(x => x.Username == model.Username);

            if (user == null || !BCryptNet.Verify(model.Password, user.PasswordHash))
            {
                return null; // or throw exception
            }

            // jwt generation
            var jwtToken = _iJWTUtils.GenerateJWTToken(user);
            return new UserResponseDTO(user, jwtToken);
        }

        public void Create(User user)
        {
            _userRepository.Create(user);
            _userRepository.Save();
        }

        public IEnumerable<User> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public User GetById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
