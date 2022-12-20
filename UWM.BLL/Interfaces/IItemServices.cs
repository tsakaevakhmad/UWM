using UWM.Domain.DomainModels.Filters;
using UWM.Domain.DTO;
using UWM.Domain.Entity;

namespace UWM.BLL.Interfaces
{
    internal interface IItemServices
    {
        Task<int> Create(ItemDto item);
        Task<ItemDto> Get(int id);
        Task<IEnumerable<ItemDto>> GetAll();
        Task<IEnumerable<ItemDto>> GetByFilter(ItemFilter filter);
        Task Update(ItemDto item);
        Task Delete(int id);
    }
}
