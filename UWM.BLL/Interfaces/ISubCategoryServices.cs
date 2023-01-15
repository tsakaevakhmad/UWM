using Microsoft.EntityFrameworkCore;
using UWM.DAL.Data;
using UWM.Domain.DTO.SubCategory;
using UWM.Domain.Entity;

namespace UWM.BLL.Interfaces
{
    public interface ISubCategoryServices
    {
        Task<int> Create(SubCategoryDto subCategory);
        Task Delete(int id);
        Task<IEnumerable<SubCategoryDto>> GetAll();
        Task<SubCategoryDto> Get(int id);
        Task Update(SubCategoryDto subCategory);
    }
}
