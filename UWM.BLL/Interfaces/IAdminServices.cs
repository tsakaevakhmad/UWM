using UWM.Domain.DTO.Admin;

namespace UWM.BLL.Interfaces
{
    public interface IAdminServices
    {
        public Task<RoleDTO> AddRole(RoleDTO role);
        public Task<RoleDTO> DeleteRole(string id);
        public Task<IEnumerable<RoleDTO>> GetRole();
        public Task<IEnumerable<UsersDTO>> GetUsers();
        public Task<UsersDTO> DeleteUser(string id);
        public Task<UserRoleDTO> DeleteUserRole(UsersToRoleDTO delete);
        public Task<UserRoleDTO> AddUserRole(UsersToRoleDTO add);
        public Task<UsersDTO> GetUser(string id);
    }
}
