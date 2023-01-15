using UWM.DAL.Interfaces.Base;
using UWM.Domain.Entity;

namespace UWM.DAL.Interfaces.Warehouses
{
    public interface IWarehouseRepository : IRepositoryGetAll<Warehouse>,
        IRepositoryUpdate<Warehouse>, IRepositoryDelete<Warehouse>, IRepositoryGet<Warehouse>
    {
        Task<int> Create(Warehouse warehose);
    }
}
