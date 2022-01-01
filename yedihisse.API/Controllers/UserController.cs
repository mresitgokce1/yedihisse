using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _userService.GetAllAsync();

            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result.Data);
            else
                return BadRequest(result.Message + " " + result.Exception.Message);
        }

        [HttpGet("{userId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Get(int userId)
        {
            var result = await _userService.GetAsync(userId);

            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result.Data);
            else
                return BadRequest(result.Message + " " + result.Exception.Message);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Add([FromBody] UserAddDto userAddDto)
        {
            var result = await _userService.AddAsync(userAddDto, GetCurrentUser().Id);

            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result.Data);
            else
                return BadRequest(result.Message + " " + result.Exception.Message);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update([FromBody] UserUpdateDto userUpdateDto)
        {
            var result = await _userService.UpdateAsync(userUpdateDto, GetCurrentUser().Id);

            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result.Data);
            else
                return BadRequest(result.Message + " " + result.Exception.Message);
        }

        private UserLoggedinDto GetCurrentUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            if (identity != null)
            {
                var userclaims = identity.Claims;

                return new UserLoggedinDto
                {
                    Id = Convert.ToInt32(userclaims.FirstOrDefault(u=>u.Type == ClaimTypes.NameIdentifier)?.Value),
                    UserPhoneNumber = userclaims.FirstOrDefault(u => u.Type == ClaimTypes.Name)?.Value,
                    FirstName = userclaims.FirstOrDefault(u => u.Type == ClaimTypes.GivenName)?.Value,
                    LastName = userclaims.FirstOrDefault(u => u.Type == ClaimTypes.Surname)?.Value
                };
            }

            return null;
        }
    }
}
