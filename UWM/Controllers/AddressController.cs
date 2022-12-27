using Microsoft.AspNetCore.Mvc;
using UWM.BLL.Interfaces;
using UWM.Domain.DTO.Watehouses;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UWM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressServices _address;

        public AddressController(IAddressServices address) 
        { 
            _address = address; 
        }

        // PUT api/<AddressController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] AddressDto address)
        {
            if (id == address.Id)
            {
                await _address.Update(address);
            }
        }
    }
}
