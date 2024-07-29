using Models;

namespace Interfaces
{
    public interface IUserRoleService
    {
        Task<IBaseResponse<UserRoles>> AddRole(int userId, int roleId);
        Task<IBaseResponse<UserRoles>> DeleteRole(int userId, int roleId);
    }
}
