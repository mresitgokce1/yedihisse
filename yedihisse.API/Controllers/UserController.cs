using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using AutoMapper.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using yedihisse.Business.Abstract;
using yedihisse.Business.Utilities.Security.Token.Abstract;
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
        private readonly IUserTypeService _userTypeService;
        private readonly ITokenService _tokenService;

        public UserController(IUserService userService, IUserTypeService userTypeService, ITokenService tokenService)
        {
            _userService = userService;
            _userTypeService = userTypeService;
            _tokenService = tokenService;
        }

        [HttpGet()]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllUser()
        {
            var result = await _userService.GetAllAsync();

            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result.Data);
            else if(result.ResultStatus == ResultStatus.Error)
                return BadRequest(result.Message);
            else
                return BadRequest(result.Message + " " + result.Exception);
        }

        [HttpGet("{userId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Get(int userId)
        {
            var result = await _userService.GetAsync(userId,true,false);

            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result.Data);
            else if (result.ResultStatus == ResultStatus.Error)
                return BadRequest(result.Message);
            else
                return BadRequest(result.Message + " " + result.Exception);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Add([FromBody] UserAddDto userAddDto)
        {
            var result = await _userService.AddAsync(userAddDto, _tokenService.DecodeToken().Id);

            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result.Data);
            else if (result.ResultStatus == ResultStatus.Error)
                return BadRequest(result.Message);
            else
                return BadRequest(result.Message + " " + result.Exception);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update([FromBody] UserUpdateDto userUpdateDto)
        {
            var result = await _userService.UpdateAsync(userUpdateDto, _tokenService.DecodeToken().Id);

            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result.Data);
            else if (result.ResultStatus == ResultStatus.Error)
                return BadRequest(result.Message);
            else
                return BadRequest(result.Message + " " + result.Exception);
        }

        [HttpGet("count")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CountAllUser()
        {
            var result = await _userService.CountAsync(true,false);

            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result.Data);
            else if (result.ResultStatus == ResultStatus.Error)
                return BadRequest(result.Message);
            else
                return BadRequest(result.Message + " " + result.Exception);
        }

        [HttpDelete("{userId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int userId)
        {
            var result = await _userService.DeleteAsync(userId, _tokenService.DecodeToken().Id);

            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result.Message);
            else if (result.ResultStatus == ResultStatus.Error)
                return BadRequest(result.Message);
            else
                return BadRequest(result.Message + " " + result.Exception);
        }

        [HttpDelete("harddelete/{userId}")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> HardDelete(int userId)
        {
            var result = await _userService.HardDeleteAsync(userId);

            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result.Message);
            else if (result.ResultStatus == ResultStatus.Error)
                return BadRequest(result.Message);
            else
                return BadRequest(result.Message + " " + result.Exception);
        }

        [HttpPost("type")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddType([FromBody] UserTypeAddDto userTypeAddDto)
        {
            var result = await _userTypeService.AddAsync(userTypeAddDto, _tokenService.DecodeToken().Id);

            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result.Data);
            else if (result.ResultStatus == ResultStatus.Error)
                return BadRequest(result.Message);
            else
                return BadRequest(result.Message + " " + result.Exception);
        }
    }
}
