using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UWM.Domain.Entity;

namespace UWM.DAL.Data
{
    public class AppDBContext : IdentityDbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options)
            : base(options) { }
        public DbSet<Provider> Provider { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Warehouse> Warehous { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<SubCategory> SubCategory { get; set; }
        public DbSet<Item> Item { get; set; }
    }
}
