using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using yedihisse.Business.Utilities.Security.Token.Abstract;

namespace yedihisse.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyCorsPolicy")]
    public class AnimalController : ControllerBase
    {
        private readonly ITokenService _tokenService;

        public AnimalController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }
    }
}
