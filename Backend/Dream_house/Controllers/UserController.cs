﻿using System;
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


        [HttpPost("auth")]
        public IActionResult Create(UserRequestDTO user)
        {
            var userToCreate = new User
            {
                FirstName = user.FirstName,
                Role = Role.User,
                PasswordHash = BCryptNet.HashPassword(user.Password)
            };

            // should add the context
            // should add Auth
            return Ok();
        }

        [Authorization(Role.Administrator)]
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = _userService.GetAllUsers();
            return Ok(users);
        }
    }
}