using UWM.Domain.DTO.Category;
using UWM.Domain.Entity;

namespace UWM.BLL.Interfaces
{
    public interface ICategoryServices
    {
        Task<int> Create(CategoryDto category);
        Task Delete(int id);
        Task<CategoryDto> Get(int id);
        Task<IEnumerable<CategoryDto>> GetAll();
        Task Update(CategoryDto category);
    }
}
