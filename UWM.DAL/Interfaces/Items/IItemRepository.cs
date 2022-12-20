using UWM.DAL.Interfaces.Base;
using UWM.Domain.DomainModels.Filters;
using UWM.Domain.Entity;

namespace UWM.DAL.Interfaces.Items
{
    public interface IItemRepository :
        IRepositoryCreate<Item>,
        IRepositoryUpdate<Item>,
        IRepositoryDelete<Item>,
        IRepositoryGet<Item>,
        IRepositoryGetAll<Item>
    {
        Task<IEnumerable<Item>> GetByFilter(ItemFilter filter);
        Task<IEnumerable<Item>> GetBySubCategory(int subCategoryId);
    }
}
