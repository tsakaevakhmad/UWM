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
        public async Task<int> Create(Address address, Warehouse warehouse)
        {
            address.Warehouse = warehouse;
            await _db.Address.AddAsync(address);
            await _db.Warehous.AddAsync(warehouse);
            return await _db.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            _db.Address.Remove(await _db.Address.FindAsync(id));
        }

        public async Task<IEnumerable<Warehouse>> GetAll()
        {
            return await _db.Warehous.Include(a => a.Address).ToListAsync();
        }

        public async Task Update(Warehouse item)
        {
            var result = _db.Entry<Warehouse>(item);
            result.State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }
    }
}
