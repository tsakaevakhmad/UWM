using UWM.DAL.Interfaces.Base;
using UWM.Domain.Entity;

namespace UWM.DAL.Interfaces.Warehouses
{
    public interface IWarehouseRepository : IRepositoryGetAll<WarehouseDto>,
        IRepositoryUpdate<WarehouseDto>, IRepositoryDelete<WarehouseDto>
    {
        Task<int> Create(Address address, WarehouseDto warehose);
    }
}
