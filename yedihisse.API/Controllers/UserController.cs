using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using yedihisse.Business.Abstract;
using yedihisse.Entities.Dtos;
using yedihisse.Shared.Utilities.Results.Complex_Type;

namespace yedihisse.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyCorsPolicy")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Seller")]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAllAsync();
            return Ok(users);
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> Get(int userId)
        {
            var user = await _userService.GetAsync(userId);
            return Ok(user.Data);
        }

        [HttpPost()]
        public async Task<IActionResult> Add([FromBody] UserAddDto userAddDto)
        {
            var user = await _userService.AddAsync(userAddDto, 1);
            return Ok(user);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UserUpdateDto userUpdateDto)
        {
            var user = await _userService.UpdateAsync(userUpdateDto, 1);
            return Ok(user);
        }
    }
}
