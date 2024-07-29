using Interfaces;
using Models;

namespace Interfaces
{
    public interface IRoleService
    {
        Task<IBaseResponse<Roles>> GetRole(int roleId);
        Task<IBaseResponse<Roles>> CreateRole(Roles role);
        Task<IBaseResponse<Roles>> UpdateRole(int roleId, Roles role);
        Task<IBaseResponse<Roles>> DeleteRole(int roleId);
    }
}
