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

        public async Task<int> Create(Warehouse warehouse)
        {
            warehouse.Address = warehouse.Address;
            await _db.Address.AddAsync(warehouse.Address);
            await _db.Warehous.AddAsync(warehouse);
            
            try
            {
                await _db.SaveChangesAsync();
                return warehouse.Id;
            }
            catch
            {
                throw new Exception();
            }
        }

        public async Task Delete(int id)
        {
            var item = await _db.Warehous.FindAsync(id);
            if (item == null)
                throw new Exception();
            
            _db.Warehous.Remove(item);
            
            try
            {
                await _db.SaveChangesAsync();
            }
            catch
            {
                throw new Exception();
            }
        }

        public async Task<Warehouse> Get(int id)
        {
            return await _db.Warehous.Include(x => x.Address).Where(x => x.Id == id).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Warehouse>> GetAll()
        {
            return await _db.Warehous.Include(a => a.Address).AsNoTracking().ToListAsync();
        }

        public async Task Update(Warehouse item)
        {
            var address = _db.Entry<Address>(item.Address);
            address.State = EntityState.Modified;

            var warehouse = _db.Entry<Warehouse>(item);
            warehouse.State = EntityState.Modified;
            
            try
            {
                await _db.SaveChangesAsync();
            }
            catch
            {
                throw new Exception();
            }
        }
    }
}
