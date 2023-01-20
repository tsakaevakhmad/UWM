
using UWM.Domain.DTO.Watehouses;

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
