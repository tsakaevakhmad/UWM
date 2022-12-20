using Microsoft.EntityFrameworkCore;
using UWM.DAL.Data;
using UWM.DAL.Interfaces.Categories;
using UWM.Domain.Entity;

namespace UWM.DAL.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDBContext _db;

        public CategoryRepository(AppDBContext db) 
        {
            _db = db;
        }
        public async Task<int> Create(Category item)
        {
            await _db.AddAsync(item);
            return await _db.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            _db.Remove(await _db.Category.FindAsync(id));
        }

        public async Task<Category> Get(int id)
        {
            return await _db.Category.Include(s => s.SubCategories).Where(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _db.Category.Include(s => s.SubCategories).ToListAsync();
        }

        public async Task Update(Category item)
        {
            var result = _db.Entry<Category>(item);
            result.State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }
    }
}
