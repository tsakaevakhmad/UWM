using Microsoft.EntityFrameworkCore;
using UWM.DAL.Data;
using UWM.DAL.Interfaces.Warehouses;
using UWM.Domain.Entity;

namespace UWM.DAL.Repositories
{
    public class WarehouseRepository : IWarehouseRepository
    {
        private AppDBContext _db;

        public WarehouseRepository(AppDBContext db) 
        {
            _db = db;
        }
        public async Task<int> Create(Address address, WarehouseDto warehouse)
        {
            address.Warehouse = warehouse;
            await _db.Address.AddAsync(address);
            await _db.Warehous.AddAsync(warehouse);
            return await _db.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var item = await _db.Address.FindAsync(id);
            if (item == null)
                return;
            _db.Address.Remove(item);
        }

        public async Task<IEnumerable<WarehouseDto>> GetAll()
        {
            return await _db.Warehous.Include(a => a.Address).ToListAsync();
        }

        public async Task Update(WarehouseDto item)
        {
            var result = _db.Entry<WarehouseDto>(item);
            result.State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }
    }
}
