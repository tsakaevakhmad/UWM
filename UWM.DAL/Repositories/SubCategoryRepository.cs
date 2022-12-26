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
            var item = _db.SubCategory.Find(id);
            if (item == null)
                return;
            _db.SubCategory.Remove(item);
            _db.SaveChanges();
        }

        public async Task<IEnumerable<SubCategory>> GetAll()
        {
            return await _db.SubCategory.ToListAsync();
        }

        public async void Update(SubCategory item)
        {
            var result = _db.Entry<SubCategory>(item);
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
