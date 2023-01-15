using Microsoft.AspNetCore.Mvc;
using UWM.BLL.Interfaces;
using UWM.Domain.DTO.Watehouses;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UWM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehouseController : ControllerBase
    {
        private readonly IWarehouseServices _warehouse;

        public WarehouseController(IWarehouseServices warehouse) 
        { 
            _warehouse = warehouse; 
        }

        // GET: api/<WarehouseController>
        [HttpGet]
        public async Task<IEnumerable<WarehouseDto>> Get()
        {
            return await _warehouse.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<WarehouseDto> Get(int id)
        {
            return await _warehouse.Get(id);
        }

        // POST api/<WarehouseController>
        [HttpPost]
        public async Task<int> Post([FromBody] WarehouseDto warehose)
        {
            return await _warehouse.Create(warehose);
        }

        // PUT api/<WarehouseController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] WarehouseDto warehose)
        {
            await _warehouse.Update(warehose);
        }

        // DELETE api/<WarehouseController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _warehouse.Delete(id);
        }
    }
}
