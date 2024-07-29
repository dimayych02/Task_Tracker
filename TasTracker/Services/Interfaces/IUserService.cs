using Interfaces;
using Models;
using RoleEnum;

namespace Interfaces
{
    public interface IUserService
    {
        Task<IBaseResponse<User>> GetUser(int userId);
        Task<IBaseResponse<User>> CreateUser(User user);
        Task<IBaseResponse<User>> UpdateUser(int userId, User user);
        Task<IBaseResponse<User>> DeleteUser(int userId);
        bool HasAdminRights(User user, params UserRole[] role);
    }
}
