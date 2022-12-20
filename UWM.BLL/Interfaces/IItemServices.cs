using UWM.Domain.DTO;

namespace UWM.BLL.Interfaces
{
    internal interface IItemServices
    {
        Task<int> Create(ItemDto item);
        Task<ItemDto> Get(int id);
        Task<IEnumerable<ItemDto>> GetAll();
        Task<IEnumerable<ItemDto>> GetBySubCategory(int subCategoryid);
        Task Update(ItemDto item);
        Task Delete(int id);
    }
}
