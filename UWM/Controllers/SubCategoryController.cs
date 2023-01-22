using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using UWM.BLL.Interfaces;
using UWM.Domain.DTO.SubCategory;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UWM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "User")]
    public class SubCategoryController : ControllerBase
    {
        private readonly ISubCategoryServices _subCategory;

        public SubCategoryController(ISubCategoryServices subCategory)
        {
            _subCategory = subCategory;
        }

        // GET: api/<SubCategoryController>
        [HttpGet]
        public async Task<IEnumerable<SubCategoryDto>> Get()
        {
            return await _subCategory.GetAll();
        }

        // GET: api/<SubCategoryController>
        [HttpGet("{id}")]
        public async Task<SubCategoryDto> Get(int id)
        {
            return await _subCategory.Get(id);
        }

        // POST api/<SubCategoryController>
        [HttpPost]
        public async Task<int> Post([FromBody] SubCategoryDto subCategory)
        {
            return await _subCategory.Create(subCategory);
        }

        // PUT api/<SubCategoryController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] SubCategoryDto subCategory)
        {
            if (id == subCategory.Id)
            {
                await _subCategory.Update(subCategory);
            }
        }

        // DELETE api/<SubCategoryController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _subCategory.Delete(id);
        }
    }
}
