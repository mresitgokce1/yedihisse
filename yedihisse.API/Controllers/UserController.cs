using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using yedihisse.Business.Abstract;
using yedihisse.Entities.Dtos;
using yedihisse.Shared.Utilities.Results.Complex_Type;

namespace yedihisse.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAllAsync();
            var x = users.Data.Users;

            return Ok(new { results = "asd" });
        }

        [HttpGet("{addressId}")]
        public async Task<IActionResult> Get(int addressId)
        {
            var address = await _userService.GetAsync(addressId);
            return Ok(address.Data);
        }

        [HttpPost]
        public async Task<IActionResult> Add(UserAddDto userAddDto)
        {
            int userId = 1;
            var addedAddress = await _userService.AddAsync(userAddDto, userId);
            return Ok(addedAddress);
        }
    }
}
