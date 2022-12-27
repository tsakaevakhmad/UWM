using Microsoft.AspNetCore.Mvc;
using UWM.BLL.Interfaces;
using UWM.Domain.DTO.Providers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UWM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProviderController : ControllerBase
    {
        private readonly IProviderServices _provider;

        public ProviderController(IProviderServices provider) 
        { 
            _provider = provider; 
        }

        // GET: api/<ProviderController>
        [HttpGet]
        public async Task<IEnumerable<ProviderDto>> Get()
        {
            return await _provider.GetAll();
        }

        // POST api/<ProviderController>
        [HttpPost]
        public async Task Post([FromBody] ProviderDto provider)
        {
            await _provider.Create(provider);
        }

        // PUT api/<ProviderController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] ProviderDto provider)
        {
            if (id == provider.Id)
            {
                await _provider.Update(provider);
            }
        }

        // DELETE api/<ProviderController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _provider.Delete(id);
        }
    }
}
