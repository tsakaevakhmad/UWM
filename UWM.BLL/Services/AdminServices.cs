using Microsoft.AspNetCore.Identity;
using UWM.Domain.DTO.Admin;
using UWM.BLL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace UWM.BLL.Services
{
    public class AdminServices : IAdminServices
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AdminServices(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<RoleDTO> AddRole(RoleDTO role)
        {
            if (!await _roleManager.RoleExistsAsync(role.Name))
            {
                await _roleManager.CreateAsync(new IdentityRole(role.Name));
            }
            var result = _roleManager.FindByNameAsync(role.Name);
            return new RoleDTO { Name = result.Result.Name, Id = result.Result.Id };
        }

        public async Task<UserRoleDTO> AddUserRole(UsersToRoleDTO add)
        {
            var user = await _userManager.FindByIdAsync(add.UserId);
            if (user != null)
            {
                var role = await _roleManager.FindByIdAsync(add.RoleId);
                if (role != null)
                {
                    var result = new UserRoleDTO { Id = role.Id, Name = user.UserName, RoleName = role.Name };
                    await _userManager.AddToRoleAsync(user, role.Name);
                    return result;
                }
                return null;
            }
            return null;
        }

        public async Task<RoleDTO> DeleteRole(string id)
        {
            if (id == null)
               return null;

            if (await _roleManager.RoleExistsAsync(_roleManager.FindByIdAsync(id).Result.Name))
            {
                var result = _roleManager.FindByIdAsync(id);
                await _roleManager.DeleteAsync(_roleManager.FindByIdAsync(id).Result);
                return new RoleDTO { Name = result.Result.Name, Id = result.Result.Id };
            }
            return null;
        }

        public async Task<UsersDTO> DeleteUser(string id)
        {
            if (id == null)
                return null;

            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                var result = new UsersDTO() { Id = user.Id, UserName = user.UserName, Email = user.Email, Phone = user.PhoneNumber, UserRole = _userManager.GetRolesAsync(user).Result.ToList() };
                await _userManager.DeleteAsync(user);
                return result;
            }
            return null;
        }

        public async Task<UserRoleDTO> DeleteUserRole(UsersToRoleDTO delete)
        {
            if (delete.UserId == null | delete.RoleId == null)
                return null;

            var user = await _userManager.FindByIdAsync(delete.UserId);
            if (user != null)
            {
                var role = await _roleManager.FindByIdAsync(delete.RoleId);
                if (role != null)
                {
                    var result = new UserRoleDTO { Id = role.Id, Name = user.UserName, RoleName = role.Name };
                    await _userManager.RemoveFromRoleAsync(user, role.Name);
                    return result;
                }
                return null;
            }
            return null;
        }

        public async Task<IEnumerable<RoleDTO>> GetRole()
        {
            var result = from r in _roleManager.Roles select new RoleDTO { Id = r.Id, Name = r.Name };
            return await result.ToListAsync();
        }

        public async Task<IEnumerable<UsersDTO>> GetUsers()
        {
            var result = from u in await _userManager.Users.AsNoTracking().ToListAsync()
                         select new UsersDTO
                         {
                             Id = u.Id,
                             UserName = u.UserName,
                             Email = u.Email,
                             EmailConfirmed = u.EmailConfirmed,
                             Phone = u.PhoneNumber,
                             UserRole = _userManager.GetRolesAsync(u).Result.ToList()
                         };

            return result.ToList();
        }

        public async Task<UsersDTO> GetUser(string id)
        {
            var result = await _userManager.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
                         
            return new UsersDTO
            { 
                Id = result.Id,
                UserName = result.UserName,
                Email = result.Email,
                EmailConfirmed = result.EmailConfirmed, 
                Phone = result.PhoneNumber, 
                UserRole = _userManager.GetRolesAsync(result).Result.ToList() 
            };
        }
    }
}
