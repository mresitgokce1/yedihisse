using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using yedihisse.Business.Abstract;
using yedihisse.DataAccess.Abstract;
using yedihisse.Entities.Concrete;
using yedihisse.Entities.Dtos;

namespace yedihisse.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;

        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var addresses = await _addressService.GetAll();
            return Ok(addresses.Data.Addresses);
        }

        [HttpGet("{addressId}")]
        public async Task<IActionResult> Get(int addressId)
        {
            var address = await _addressService.Get(addressId);
            return Ok(address.Data);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddressAddDto addressAddDto)
        {
            int userId = 15;
            var addedAddress = await _addressService.Add(addressAddDto, userId);
            return Ok(addedAddress);
        }
    }
}
