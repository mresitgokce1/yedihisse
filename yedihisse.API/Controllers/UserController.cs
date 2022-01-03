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

        #region USER OPERATION

        [HttpGet]
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
        public async Task<IActionResult> GetUser(int userId)
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
        public async Task<IActionResult> AddUser([FromBody] UserAddDto userAddDto)
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
        public async Task<IActionResult> UpdateUser([FromBody] UserUpdateDto userUpdateDto)
        {
            var result = await _userService.UpdateAsync(userUpdateDto, _tokenService.DecodeToken().Id);

            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result.Data);
            else if (result.ResultStatus == ResultStatus.Error)
                return BadRequest(result.Message);
            else
                return BadRequest(result.Message + " " + result.Exception);
        }

        [HttpGet("Count")]
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
        public async Task<IActionResult> DeleteUser(int userId)
        {
            var result = await _userService.DeleteAsync(userId, _tokenService.DecodeToken().Id);

            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result.Message);
            else if (result.ResultStatus == ResultStatus.Error)
                return BadRequest(result.Message);
            else
                return BadRequest(result.Message + " " + result.Exception);
        }

        [HttpDelete("HardDelete/{userId}")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> HardDeleteUser(int userId)
        {
            var result = await _userService.HardDeleteAsync(userId);

            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result.Message);
            else if (result.ResultStatus == ResultStatus.Error)
                return BadRequest(result.Message);
            else
                return BadRequest(result.Message + " " + result.Exception);
        }

        #endregion

        #region USER TYPE OPERATION

        [HttpGet("Type")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllUserType()
        {
            var result = await _userTypeService.GetAllAsync();

            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result.Data);
            else if (result.ResultStatus == ResultStatus.Error)
                return BadRequest(result.Message);
            else
                return BadRequest(result.Message + " " + result.Exception);
        }

        [HttpGet("Type/{userId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetUserType(int userTypeId)
        {
            var result = await _userTypeService.GetAsync(userTypeId, true, false);

            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result.Data);
            else if (result.ResultStatus == ResultStatus.Error)
                return BadRequest(result.Message);
            else
                return BadRequest(result.Message + " " + result.Exception);
        }

        [HttpPost("Type")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddUserType([FromBody] UserTypeAddDto userTypeAddDto)
        {
            var result = await _userTypeService.AddAsync(userTypeAddDto, _tokenService.DecodeToken().Id);

            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result.Data);
            else if (result.ResultStatus == ResultStatus.Error)
                return BadRequest(result.Message);
            else
                return BadRequest(result.Message + " " + result.Exception);
        }

        [HttpPut("Type")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateUserType([FromBody] UserTypeUpdateDto userTypeUpdateDto)
        {
            var result = await _userTypeService.UpdateAsync(userTypeUpdateDto, _tokenService.DecodeToken().Id);

            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result.Data);
            else if (result.ResultStatus == ResultStatus.Error)
                return BadRequest(result.Message);
            else
                return BadRequest(result.Message + " " + result.Exception);
        }

        [HttpGet("Type/Count")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CountAllUserType()
        {
            var result = await _userTypeService.CountAsync(true, false);

            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result.Data);
            else if (result.ResultStatus == ResultStatus.Error)
                return BadRequest(result.Message);
            else
                return BadRequest(result.Message + " " + result.Exception);
        }

        [HttpDelete("Type/{userId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteUserType(int userTypeId)
        {
            var result = await _userTypeService.DeleteAsync(userTypeId, _tokenService.DecodeToken().Id);

            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result.Message);
            else if (result.ResultStatus == ResultStatus.Error)
                return BadRequest(result.Message);
            else
                return BadRequest(result.Message + " " + result.Exception);
        }

        [HttpDelete("Type/HardDelete/{userId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> HardDeleteUserType(int userTypeId)
        {
            var result = await _userTypeService.HardDeleteAsync(userTypeId);

            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result.Message);
            else if (result.ResultStatus == ResultStatus.Error)
                return BadRequest(result.Message);
            else
                return BadRequest(result.Message + " " + result.Exception);
        }

        #endregion
    }
}
