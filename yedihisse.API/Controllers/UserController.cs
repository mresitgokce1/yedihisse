using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
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
        private readonly IUserJoinTypeService _userJoinTypeService;
        private readonly ITokenService _tokenService;

        public UserController(IUserService userService, IUserTypeService userTypeService, IUserJoinTypeService userJoinTypeService, ITokenService tokenService)
        {
            _userService = userService;
            _userTypeService = userTypeService;
            _userJoinTypeService = userJoinTypeService;
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
            var result = await _userService.GetAsync(userId);

            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result.Data);
            else if (result.ResultStatus == ResultStatus.Error)
                return BadRequest(result.Message);
            else
                return BadRequest(result.Message + " " + result.Exception);
        }

        [HttpGet("Detail/{userDetailId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetUserDetail(int userDetailId)
        {
            var result = await _userService.GetDetailAsync(userDetailId);

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
            var result = await _userService.CountAsync();

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

        [HttpGet("Type/{userTypeId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetUserType(int userTypeId)
        {
            var result = await _userTypeService.GetAsync(userTypeId);

            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result.Data);
            else if (result.ResultStatus == ResultStatus.Error)
                return BadRequest(result.Message);
            else
                return BadRequest(result.Message + " " + result.Exception);
        }

        [HttpGet("Type/Detail/{userTypeId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetUserTypeDetail(int userTypeId)
        {
            var result = await _userTypeService.GetDetailAsync(userTypeId);

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
            var result = await _userTypeService.CountAsync();

            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result.Data);
            else if (result.ResultStatus == ResultStatus.Error)
                return BadRequest(result.Message);
            else
                return BadRequest(result.Message + " " + result.Exception);
        }

        [HttpDelete("Type/{userTypeId}")]
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

        [HttpDelete("Type/HardDelete/{userTypeId}")]
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

        #region USER TYPE JOIN OPERATION

        [HttpGet("JoinType/{userJoinTypeId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetUserJoinType(int userJoinTypeId)
        {
            var result = await _userJoinTypeService.GetAsync(userJoinTypeId);

            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result.Data);
            else if (result.ResultStatus == ResultStatus.Error)
                return BadRequest(result.Message);
            else
                return BadRequest(result.Message + " " + result.Exception);
        }

        [HttpGet("JoinType/Detail/{userJoinTypeId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetUserJoinTypeDetail(int userJoinTypeId)
        {
            var result = await _userJoinTypeService.GetDetailAsync(userJoinTypeId);

            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result.Data);
            else if (result.ResultStatus == ResultStatus.Error)
                return BadRequest(result.Message);
            else
                return BadRequest(result.Message + " " + result.Exception);
        }

        [HttpGet("JoinType")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllUserJoinType()
        {
            var result = await _userJoinTypeService.GetAllAsync();

            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result.Data);
            else if (result.ResultStatus == ResultStatus.Error)
                return BadRequest(result.Message);
            else
                return BadRequest(result.Message + " " + result.Exception);
        }

        [HttpPost("JoinType")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddUserJoinType([FromBody] UserJoinTypeAddDto userJoinTypeAddDto)
        {
            var result = await _userJoinTypeService.AddAsync(userJoinTypeAddDto, _tokenService.DecodeToken().Id);

            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result.Data);
            else if (result.ResultStatus == ResultStatus.Error)
                return BadRequest(result.Message);
            else
                return BadRequest(result.Message + " " + result.Exception);
        }

        [HttpPut("JoinType")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateUserJoinType([FromBody] UserJoinTypeUpdateDto userJoinTypeUpdateDto)
        {
            var result = await _userJoinTypeService.UpdateAsync(userJoinTypeUpdateDto, _tokenService.DecodeToken().Id);

            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result.Data);
            else if (result.ResultStatus == ResultStatus.Error)
                return BadRequest(result.Message);
            else
                return BadRequest(result.Message + " " + result.Exception);
        }

        [HttpDelete("JoinType/{userJoinTypeId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteUserJoinType(int userJoinTypeId)
        {
            var result = await _userJoinTypeService.DeleteAsync(userJoinTypeId, _tokenService.DecodeToken().Id);

            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result.Message);
            else if (result.ResultStatus == ResultStatus.Error)
                return BadRequest(result.Message);
            else
                return BadRequest(result.Message + " " + result.Exception);
        }

        [HttpDelete("JoinType/HardDelete/{userJoinTypeId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> HardDeleteUserJoinType(int userJoinTypeId)
        {
            var result = await _userJoinTypeService.HardDeleteAsync(userJoinTypeId);

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
