using UWM.Domain.DTO.Items;

namespace UWM.BLL.Interfaces
{
    public interface IItemServices
    {
        Task<int> Create(ItemDto item);
        Task<ItemDto> Get(int id);
        Task<IEnumerable<ItemListDto>> GetAll();
        Task<IEnumerable<ItemListDto>> GetBySubCategory(int subCategoryid);
        Task Update(ItemDto item);
        Task Delete(int id);
    }
}
