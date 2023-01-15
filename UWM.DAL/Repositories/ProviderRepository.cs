using Microsoft.EntityFrameworkCore;
using System.Data;
using UWM.DAL.Data;
using UWM.DAL.Interfaces.Providers;
using UWM.Domain.Entity;

namespace UWM.DAL.Repositories
{
    public class ProviderRepository : IProviderRepository
    {
        private readonly AppDBContext _db;

        public ProviderRepository(AppDBContext db) 
        {
            _db = db;
        }

        public async Task<int> Create(Provider item)
        {
            await _db.Provider.AddAsync(item);
            
            try
            {
                await _db.SaveChangesAsync();
                return item.Id;
            }
            catch
            {
                throw new Exception();
            }
        }

        public async Task Delete(int id)
        {
            var item = await _db.Provider.FindAsync(id);
            if (item == null)
                throw new Exception();
            
            _db.Provider.Remove(item);
            
            try
            {
                await _db.SaveChangesAsync();
            }
            catch
            {
                throw new Exception();
            }
        }

        public async Task<Provider> Get(int id)
        {
            return await _db.Provider.FindAsync(id);
        }

        public async Task<IEnumerable<Provider>> GetAll()
        {
            return await _db.Provider
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task Update(Provider item)
        {
            var result = _db.Entry<Provider>(item);
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
