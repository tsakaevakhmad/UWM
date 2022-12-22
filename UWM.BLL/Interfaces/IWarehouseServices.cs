
using UWM.Domain.DTO.Watehouses;
using UWM.Domain.Entity;

namespace UWM.BLL.Interfaces
{
    public interface IWarehouseServices
    {
        Task<int> Create(AddressDto address, Warehouse warehouse);
        Task Delete(int id);
        Task<IEnumerable<Warehouse>> GetAll();
        Task Update(Warehouse warehouse);
    }
}
