using Microsoft.EntityFrameworkCore;
using UWM.DAL.Data;
using UWM.DAL.Interfaces;
using UWM.Domain.DomainModels.Filters;
using UWM.Domain.Entity;

namespace UWM.DAL.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly AppDBContext _db;

        public ItemRepository(AppDBContext db) 
        {
            _db = db;
        }
        public async Task<int> Create(Item item)
        {
            await _db.Item.AddAsync(item);
            return await _db.SaveChangesAsync(); 
        }

        public async Task Delete(int id)
        {
            _db.Item.Remove(await _db.Item.FindAsync(id));
        }

        public async Task<Item> Get(int id)
        {
            return await _db.Item
                .Include(p => p.Provider)
                .Include(w => w.Warehouse)
                .Include(s => s.SubCategory)
                .Where(i => i.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Item>> GetAll()
        {
            return await _db.Item
                .Include(p => p.Provider)
                .Include(w => w.Warehouse)
                .Include(s => s.SubCategory)
                .ToListAsync();
        }

        public async Task<IEnumerable<Item>> GetByFilter(ItemFilter filter)
        {
            return await _db.Item.Include(p => p.Provider).Include(w => w.Warehouse).Include(s => s.SubCategory)
                .Where(f =>
                (filter.Title == null ? true
                : filter.Title.Length == 0 ? true
                : filter.Title[0] == null ? true
                : filter.Title.Contains(f.Title))
                & (filter.Specifications == null ? true
                : filter.Specifications.Length == 0 ? true
                : filter.Specifications[0] == null ? true
                : filter.Specifications.Contains(f.Specifications))
                & (filter.Manufacturer == null ? true
                : filter.Manufacturer.Length == 0 ? true
                : filter.Manufacturer[0] == null ? true
                : filter.Manufacturer.Contains(f.Manufacturer))
                & (filter.ProviderName == null ? true
                : filter.ProviderName.Length == 0 ? true
                : filter.ProviderName[0] == null ? true
                : filter.ProviderName.Contains(f.Provider.Name))
                & (filter.WarehouseNumber == null ? true
                : filter.WarehouseNumber.Length == 0 ? true
                : filter.WarehouseNumber[0] == null ? true
                : filter.WarehouseNumber.Contains(f.Warehouse.Number))).ToListAsync();
        }

        public async Task Update(Item item)
        {
            await _db.AddAsync(item);
            _db.Entry(item).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }
    }
}
