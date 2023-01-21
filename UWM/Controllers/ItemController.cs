using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UWM.BLL.Interfaces;
using UWM.Domain.DTO.Items;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UWM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "User")]
    public class ItemController : ControllerBase
    {
        private readonly IItemServices _item;

        public ItemController(IItemServices item)
        {
            _item = item;
        }

        // GET: api/<ItemController>
        [HttpGet]
        public async Task<IEnumerable<ItemListDto>> Get()
        {
            return await _item.GetAll();
        }

        // GET api/<ItemController>/5
        [HttpGet("{id}")]
        public async Task<ItemDto> Get(int id)
        {
            return await _item.Get(id);
        }

        // GET api/<ItemController>/5
        [HttpGet("GetBySubCategory/{subCategoryId}")]
        public async Task<IEnumerable<ItemListDto>> GetBySubCategory(int subCategoryId)
        {
            return await _item.GetBySubCategory(subCategoryId);
        }

        // POST api/<ItemController>
        [HttpPost]
        public async Task<int> Post([FromBody] ItemDto item)
        {
            return await _item.Create(item);
        }

        // PUT api/<ItemController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] ItemDto item)
        {
            if (id == item.Id)
            {
                await _item.Update(item);
            }
        }

        // DELETE api/<ItemController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _item.Delete(id);
        }
    }
}
