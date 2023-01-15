
using UWM.Domain.DTO.Watehouses;
using UWM.Domain.Entity;

namespace UWM.BLL.Interfaces
{
    public interface IWarehouseServices
    {
        Task<int> Create(WarehouseDto warehouse);
        Task Delete(int id);
        Task<IEnumerable<WarehouseDto>> GetAll();
        Task<WarehouseDto> Get(int id);
        Task Update(WarehouseDto warehouse);
    }
}
