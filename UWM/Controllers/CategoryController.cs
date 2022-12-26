using Microsoft.AspNetCore.Mvc;
using UWM.BLL.Interfaces;
using UWM.Domain.DTO.Category;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UWM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryServices _category;

        public CategoryController(ICategoryServices category) 
        { 
            _category = category; 
        }

        // GET: api/<CategoryController>
        [HttpGet]
        public async Task<IEnumerable<CategoryDto>> Get()
        {
            return await _category.GetAll();
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public async Task<CategoryDto> Get(int id)
        {
            return await _category.Get(id);
        }

        // POST api/<CategoryController>
        [HttpPost]
        public async Task<int> Post([FromBody] CategoryDto category)
        {
            return await _category.Create(category);
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] CategoryDto category)
        {
            if (id == category.Id)
            {
                await _category.Update(category);
            }
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _category.Delete(id);
        }
    }
}
