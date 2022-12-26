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

        public void Delete(int id)
        {
            var item = _db.Warehous.Find(id);
            if (item == null)
                return;
            _db.Warehous.Remove(item);
            _db.SaveChanges();
        }

        public async Task<IEnumerable<Warehouse>> GetAll()
        {
            return await _db.Warehous.Include(a => a.Address).ToListAsync();
        }

        public async void Update(Warehouse item)
        {
            var result = _db.Entry<Warehouse>(item);
            result.State = EntityState.Modified;
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
