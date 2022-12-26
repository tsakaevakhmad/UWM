using UWM.Domain.DTO.Category;

namespace UWM.BLL.Interfaces
{
    public interface ICategoryServices
    {
        Task<int> Create(CategoryDto category);
        void Delete(int id);
        Task<CategoryDto> Get(int id);
        Task<IEnumerable<CategoryDto>> GetAll();
        void Update(CategoryDto category);
    }
}
