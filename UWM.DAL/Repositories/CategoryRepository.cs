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

        public void Delete(int id)
        {
            var item = _db.Category.Find(id);
            if (item == null)
                return;
            _db.Category.Remove(item);
            _db.SaveChanges();
        }

        public async Task<Category> Get(int id)
        {
            return await _db.Category.Include(s => s.SubCategories).Where(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _db.Category.Include(s => s.SubCategories).ToListAsync();
        }

        public async void Update(Category item)
        {
            var result = _db.Entry<Category>(item);
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
