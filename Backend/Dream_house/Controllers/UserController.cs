using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BCryptNet = BCrypt.Net.BCrypt;
using Dream_house.DTOs;
using Dream_house.Models;
using Dream_house.Services.UserService;
using Dream_house.Utilities.Attributes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dream_house.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        //[Authorization(Role.Administrator)]
        [HttpGet("all")]
        public IActionResult GetAllUsers()
        {
            var users = _userService.GetAllUsers();
            return Ok(users);
        }

        [HttpGet("byId/{id}/home")]
        public IActionResult GetUserAndHome(Guid id)
        {
            var users = _userService.GetUserAndHome(id);
            return Ok(users);
        }

        [HttpGet("byId/{id}")]
        public IActionResult GetUserById(Guid id)
        {
            var user = _userService.GetUserById(id);
            return Ok(user);
        }


        [HttpPost("auth")]
        public IActionResult Auth(UserRequestDTO user)
        {
            var response = _userService.Auth(user);

            if (response == null)
            {
                return BadRequest(new { Message = "Username or Password is invalid!" });
            }

            return Ok(response);
        }


        [HttpPost("create")]
        public IActionResult Create([FromBody] UserRequestDTO user)
        {
            var userToCreate = new User
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Username = user.Username,
                Role = Role.User,
                PasswordHash = BCryptNet.HashPassword(user.Password)
            };

            // should add the context
            _userService.CreateUser(userToCreate);

            // should add Auth
            Auth(user);

            return Ok();
        }


        [HttpPut("update")]
        public IActionResult UpdateUser([FromBody] User user)
        {
            _userService.UpdateUser(user);
            return Ok();
        }

        [HttpDelete("delete")]
        public IActionResult DeleteUser([FromBody] User user)
        {
            _userService.DeleteUser(user);
            return Ok();
        }
    }
}
