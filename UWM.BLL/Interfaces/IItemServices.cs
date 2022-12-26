using UWM.Domain.DTO.Items;

namespace UWM.BLL.Interfaces
{
    public interface IItemServices
    {
        Task<int> Create(ItemDto item);
        Task<ItemDto> Get(int id);
        Task<IEnumerable<ItemDto>> GetAll();
        Task<IEnumerable<ItemDto>> GetBySubCategory(int subCategoryid);
        void Update(ItemDto item);
        void Delete(int id);
    }
}
