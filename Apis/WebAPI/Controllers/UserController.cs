﻿using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    
    public class UserController:BaseController
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        /// <summary>
        /// Get All Users
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> DemoApi()
        {
            var result = await _userService.GetAllUsers();
            if (result ==null)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        /// <summary>
        /// Get user by Id
        /// </summary>

        [HttpGet("{Id}")] 
        public async Task<IActionResult> GetById(Guid Id)
        {
            var result = await _userService.GetUserById(Id);
            if(result is null)
            {
                return BadRequest("Not found");
            } else
            return Ok(result);
        }


    }
}
