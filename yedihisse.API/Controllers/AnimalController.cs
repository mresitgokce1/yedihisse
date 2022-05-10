using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using yedihisse.Business.Abstract;
using yedihisse.Business.Utilities.Security.Token.Abstract;
using yedihisse.Entities.Dtos;
using yedihisse.Shared.Utilities.Results.Complex_Type;

namespace yedihisse.API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyCorsPolicy")]
    public class AnimalController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly IAnimalService _animalService;
        private readonly IAnimalTypeService _animalTypeService;

        public AnimalController(ITokenService tokenService, IAnimalService animalService, IAnimalTypeService animalTypeService)
        {
            _tokenService = tokenService;
            _animalService = animalService;
            _animalTypeService = animalTypeService;
        }

        #region ANIMAL OPERATION

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllAnimal()
        {
            var result = await _animalService.GetAllAsync();

            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result.Data);
            else if (result.ResultStatus == ResultStatus.Error)
                return BadRequest(result.Message);
            else
                return BadRequest(result.Message + " " + result.Exception);
        }

        [HttpGet("{animalId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAnimal(int animalId)
        {
            var result = await _animalService.GetAsync(animalId);

            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result.Data);
            else if (result.ResultStatus == ResultStatus.Error)
                return BadRequest(result.Message);
            else
                return BadRequest(result.Message + " " + result.Exception);
        }

        [HttpGet("/Detail/{animalId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAnimalDetail(int animalId)
        {
            var result = await _animalService.GetDetailAsync(animalId);

            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result.Data);
            else if (result.ResultStatus == ResultStatus.Error)
                return BadRequest(result.Message);
            else
                return BadRequest(result.Message + " " + result.Exception);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddAnimal([FromBody] AnimalAddDto animalAddDto)
        {
            var result = await _animalService.AddAsync(animalAddDto, _tokenService.DecodeToken().Id);

            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result.Data);
            else if (result.ResultStatus == ResultStatus.Error)
                return BadRequest(result.Message);
            else
                return BadRequest(result.Message + " " + result.Exception);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateAnimal([FromBody] AnimalUpdateDto animalUpdateDto)
        {
            var result = await _animalService.UpdateAsync(animalUpdateDto, _tokenService.DecodeToken().Id);

            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result.Data);
            else if (result.ResultStatus == ResultStatus.Error)
                return BadRequest(result.Message);
            else
                return BadRequest(result.Message + " " + result.Exception);
        }

        [HttpDelete("{animalId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteAnimal(int animalId)
        {
            var result = await _animalService.DeleteAsync(animalId, _tokenService.DecodeToken().Id);

            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result.Message);
            else if (result.ResultStatus == ResultStatus.Error)
                return BadRequest(result.Message);
            else
                return BadRequest(result.Message + " " + result.Exception);
        }

        [HttpDelete("HardDelete/{animalId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> HardDeleteAnimal(int animalId)
        {
            var result = await _animalService.HardDeleteAsync(animalId);

            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result.Message);
            else if (result.ResultStatus == ResultStatus.Error)
                return BadRequest(result.Message);
            else
                return BadRequest(result.Message + " " + result.Exception);
        }

        [HttpGet("Count")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CountAllAnimal()
        {
            var result = await _animalService.CountAsync();

            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result.Data);
            else if (result.ResultStatus == ResultStatus.Error)
                return BadRequest(result.Message);
            else
                return BadRequest(result.Message + " " + result.Exception);
        }

        #endregion

        #region ANIMAL TYPE OPERATION

        [HttpGet("Type")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllAnimalType()
        {
            var result = await _animalTypeService.GetAllAsync();

            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result.Data);
            else if (result.ResultStatus == ResultStatus.Error)
                return BadRequest(result.Message);
            else
                return BadRequest(result.Message + " " + result.Exception);
        }

        [HttpGet("Type/{animalTypeId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAnimalType(int animalTypeId)
        {
            var result = await _animalTypeService.GetAsync(animalTypeId);

            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result.Data);
            else if (result.ResultStatus == ResultStatus.Error)
                return BadRequest(result.Message);
            else
                return BadRequest(result.Message + " " + result.Exception);
        }

        [HttpGet("Type/Detail/{animalId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAnimalTypeDetail(int animalTypeId)
        {
            var result = await _animalTypeService.GetDetailAsync(animalTypeId);

            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result.Data);
            else if (result.ResultStatus == ResultStatus.Error)
                return BadRequest(result.Message);
            else
                return BadRequest(result.Message + " " + result.Exception);
        }

        [HttpPost("Type")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddAnimalType([FromBody] AnimalTypeAddDto animalTypeAddDto)
        {
            var result = await _animalTypeService.AddAsync(animalTypeAddDto, _tokenService.DecodeToken().Id);

            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result.Data);
            else if (result.ResultStatus == ResultStatus.Error)
                return BadRequest(result.Message);
            else
                return BadRequest(result.Message + " " + result.Exception);
        }

        [HttpPut("Type")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateAnimalType([FromBody] AnimalTypeUpdateDto animalTypeUpdateDto)
        {
            var result = await _animalTypeService.UpdateAsync(animalTypeUpdateDto, _tokenService.DecodeToken().Id);

            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result.Data);
            else if (result.ResultStatus == ResultStatus.Error)
                return BadRequest(result.Message);
            else
                return BadRequest(result.Message + " " + result.Exception);
        }

        [HttpDelete("Type/{animalTypeId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteAnimalType(int animalTypeId)
        {
            var result = await _animalTypeService.DeleteAsync(animalTypeId, _tokenService.DecodeToken().Id);

            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result.Message);
            else if (result.ResultStatus == ResultStatus.Error)
                return BadRequest(result.Message);
            else
                return BadRequest(result.Message + " " + result.Exception);
        }

        [HttpDelete("Type/HardDelete/{animalTypeId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> HardDeleteAnimalType(int animalTypeId)
        {
            var result = await _animalTypeService.HardDeleteAsync(animalTypeId);

            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result.Message);
            else if (result.ResultStatus == ResultStatus.Error)
                return BadRequest(result.Message);
            else
                return BadRequest(result.Message + " " + result.Exception);
        }

        [HttpGet("Type/Count")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CountAllAnimalType()
        {
            var result = await _animalTypeService.CountAsync();

            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result.Data);
            else if (result.ResultStatus == ResultStatus.Error)
                return BadRequest(result.Message);
            else
                return BadRequest(result.Message + " " + result.Exception);
        }

        #endregion
    }
}
