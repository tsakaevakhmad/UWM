using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UWM.Domain.Entity;


namespace UWM.DAL.Data
{
    public class AppDBContext : IdentityDbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options)
            : base(options) 
        {
            Database.EnsureCreated();
        }
        public DbSet<Provider> Provider { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Warehouse> Warehous { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<SubCategory> SubCategory { get; set; }
        public DbSet<Item> Item { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            this.SeedRoles(builder);
            this.SeedUsers(builder);
            this.SeedUserRoles(builder);
        }

        private void SeedUsers(ModelBuilder builder)
        {
            PasswordHasher<IdentityUser> passwordHasher = new PasswordHasher<IdentityUser>();
            
            IdentityUser user = new IdentityUser()
            {
                Id = "b74ddd14-6340-4840-95c2-db12554843e5",
                UserName = "Admin",
                Email = "admin@gmail.com",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                PasswordHash = passwordHasher.HashPassword(null, "admin"),
                EmailConfirmed = true,
                LockoutEnabled = false,
                PhoneNumber = "1234567890"
            };

            builder.Entity<IdentityUser>().HasData(user);
        }

        private void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole() { Id = "fab4fac1-c546-41de-aebc-a14da6895711", Name = "Administrator", ConcurrencyStamp = "1", NormalizedName = "ADMINISTRATOR" },
                new IdentityRole() { Id = "c7b013f0-5201-4317-abd8-c211f91b7330", Name = "User", ConcurrencyStamp = "2", NormalizedName = "USER" }
                );
        }

        private void SeedUserRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>() { RoleId = "fab4fac1-c546-41de-aebc-a14da6895711", UserId = "b74ddd14-6340-4840-95c2-db12554843e5" }
                );

            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>() { RoleId = "c7b013f0-5201-4317-abd8-c211f91b7330", UserId = "b74ddd14-6340-4840-95c2-db12554843e5" }
                );
        }
    } 
}
