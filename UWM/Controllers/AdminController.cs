using Microsoft.AspNetCore.Mvc;
using UWM.BLL.Interfaces;
using UWM.Domain.DTO.Admin;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UWM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminServices _adminServices;
        public AdminController(IAdminServices adminServices)
        {
            _adminServices = adminServices;
        }


        [HttpPost("Role")]
        public async Task<ActionResult<RoleDTO>> AddRole(RoleDTO role)
        {
            var result = await _adminServices.AddRole(role);
            return result;
        }

        [HttpDelete("Role/{id}")]
        public async Task<ActionResult<RoleDTO>> DeleteRole(string id)
        {
            var result = await _adminServices.DeleteRole(id);
            if (result == null)
                return BadRequest();
            return result;
        }

        // GET: api/<AdminController>
        [HttpGet("Roles")]
        public async Task<ActionResult<IEnumerable<RoleDTO>>> GetRole()
        {
            var result = await _adminServices.GetRole();
            return result.ToList();
        }

        // GET: api/<AdminController>
        [HttpGet("User/{id}")]
        public async Task<ActionResult<UsersDTO>> GetUser(string id)
        {
            var result = await _adminServices.GetUser(id);
            return result;
        }   

        // GET: api/<AdminController>
        [HttpGet("Users")]
        public async Task<ActionResult<IEnumerable<UsersDTO>>> GetUsers()
        {
            var result = await _adminServices.GetUsers();
            return result.ToList();
        }

        [HttpDelete("User/{id}")]
        public async Task<ActionResult<UsersDTO>> DeleteUser(string id)
        {
            var result = await _adminServices.DeleteUser(id);
            if (result == null)
                return BadRequest();
            return result;
        }

        [HttpDelete("UserRole")]
        public async Task<ActionResult<UserRoleDTO>> DeleteUserRole(UsersToRoleDTO model)
        {
            var result = await _adminServices.DeleteUserRole(model);
            if (result == null)
                return BadRequest();
            return result;
        }

        [HttpPost("UserRole")]
        public async Task<ActionResult<UserRoleDTO>> AddUserRole(UsersToRoleDTO model)
        {
            var result = await _adminServices.AddUserRole(model);
            if (result == null)
                return BadRequest();
            return result;
        }
    }
}
