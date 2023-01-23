using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UWM.BLL.Interfaces;
using UWM.Domain.DTO.Providers;

namespace UWM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "User")]
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

        [HttpGet("{id}")]
        public async Task<ProviderDto> Get(int id)
        {
            return await _provider.Get(id);
        }

        // POST api/<ProviderController>
        [HttpPost]
        public async Task<int> Post([FromBody] ProviderDto provider)
        {
            return await _provider.Create(provider);
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
