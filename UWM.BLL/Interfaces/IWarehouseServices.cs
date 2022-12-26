
using UWM.Domain.DTO.Watehouses;
using UWM.Domain.Entity;

namespace UWM.BLL.Interfaces
{
    public interface IWarehouseServices
    {
        Task<int> Create(AddressDto address, Warehouse warehouse);
        void Delete(int id);
        Task<IEnumerable<Warehouse>> GetAll();
        void Update(Warehouse warehouse);
    }
}
