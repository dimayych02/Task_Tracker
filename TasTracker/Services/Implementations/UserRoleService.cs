using Contexts;
using Interfaces;
using Models;

namespace Implementations
{
    public class UserRoleService 
    {

        private readonly TaskContext _taskContext;
        private readonly IRoleService _roleService;

        public UserRoleService(TaskContext taskContext, IRoleService roleService)
        {
            _taskContext = taskContext;
            _roleService = roleService;
        }


        /*public async Task<IBaseResponse<UserRoles>> AddRole(int userId, int roleId)
        {
            try
            {
                var role = await _roleService.GetRole(roleId);
                var userRole = new UserRoles { Roles = role.Data };
                await _taskContext.UserRoles.AddAsync(userRole);
            }

            catch(Exception ex)
            {

            }
        }*/
    }
}
