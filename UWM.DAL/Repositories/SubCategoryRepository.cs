using Microsoft.EntityFrameworkCore;
using UWM.DAL.Data;
using UWM.DAL.Interfaces.SubCategories;
using UWM.Domain.Entity;

namespace UWM.DAL.Repositories
{
    public class SubCategoryRepository : ISubCategoryRepository
    {
        private readonly AppDBContext _db;

        public SubCategoryRepository(AppDBContext db) 
        {
            _db = db;
        }

        public async Task<int> Create(SubCategory item)
        {
            await _db.SubCategory.AddAsync(item);
            return await _db.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var item = await _db.SubCategory.FindAsync(id);
            if (item == null)
                return;
            _db.SubCategory.Remove(item);
        }

        public async Task<IEnumerable<SubCategory>> GetAll()
        {
            return await _db.SubCategory.ToListAsync();
        }

        public async Task Update(SubCategory item)
        {
            var result = _db.Entry<SubCategory>(item);
            result.State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }
    }
}
