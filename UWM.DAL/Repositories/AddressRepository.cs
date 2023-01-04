using Microsoft.EntityFrameworkCore;
using UWM.DAL.Data;
using UWM.DAL.Interfaces.Addresses;
using UWM.Domain.Entity;

namespace UWM.DAL.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly AppDBContext _db;

        public AddressRepository(AppDBContext db) 
        {
            _db = db;
        }

        public async Task Update(Address item)
        {
            var result = _db.Entry<Address>(item);
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
