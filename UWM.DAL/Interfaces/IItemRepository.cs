using UWM.Domain.DomainModels.Filters;
using UWM.Domain.Entity;

namespace UWM.DAL.Interfaces
{
    public interface IItemRepository : IRepository<Item>
    {
        Task<IEnumerable<Item>> GetByFilter(ItemFilter filter); 
    }
}
