using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [AllowAnonymous]
        [HttpPost("token")]
        public async Task<IActionResult> Authenticate([FromBody] UserLoginDto userLoginDto)
        {
            var result = await _loginService.Authenticate(userLoginDto);

            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result.Data);
            else
                return BadRequest(result.Message);
        }
    }
}
