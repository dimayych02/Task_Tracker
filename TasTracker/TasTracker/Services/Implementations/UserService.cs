using Contexts;
using Interfaces;
using Models;
using RoleEnum;
using StatusCodeEnum;


namespace Implementations
{
    public class UserService : IUserService
    {
        private readonly TaskContext _taskContext;

        public UserService(TaskContext taskContext)
        {
            _taskContext = taskContext;
        }


        public async Task<IBaseResponse<User>> GetUser(int userId)
        {
            try
            {
               
                var user = await FindUser(userId);

                if(user is null)
                {
                    return new BaseResponse<User>()
                    {
                        Description = $"User with id:{userId} does not exist!",
                        StatusCode = HttpStatusCode.NOT_FOUND,
                    };
                }


                return new BaseResponse<User>()
                {
                    Description = $"User with id:{userId} was founded successfully!",
                    StatusCode = HttpStatusCode.OK,
                    Data = user,
                };
            }

            catch(Exception ex)
            {
                return new BaseResponse<User>()
                {
                    Description = ex.Message,
                    StatusCode = HttpStatusCode.INTERNAL_SERVER_ERROR
                };
            }
            
        }

        public async Task<IBaseResponse<User>> CreateUser(User user)
        {
            try
            {
                await _taskContext.Users.AddAsync(user);
                await _taskContext.SaveChangesAsync();

                return new BaseResponse<User>()
                {
                    Description = "User was added successfully!",
                    StatusCode = HttpStatusCode.CREATED,
                    Data = user
                };
            }
            catch(Exception ex)
            {
                return new BaseResponse<User>()
                {
                    Description = ex.Message,
                    StatusCode = HttpStatusCode.INTERNAL_SERVER_ERROR
                };
            }
            
        }


        public async Task<IBaseResponse<User>> UpdateUser(int userId, User updateUser)
        {
            try
            {
                var user = await FindUser(userId);

                if (user is null)
                {
                    return new BaseResponse<User>()
                    {
                        Description = $"User with id:{userId} does not exist!",
                        Data = null,
                        StatusCode = HttpStatusCode.NOT_FOUND,
                    };
                }


                user = updateUser;
                await _taskContext.SaveChangesAsync();

                return new BaseResponse<User>()
                {
                    Description = $"User with id:{userId} was updated successfully!",
                    StatusCode = HttpStatusCode.OK,
                    Data = user
                };

            }

            catch(Exception ex)
            {
                return new BaseResponse<User>()
                {
                    Description = ex.Message,
                    StatusCode = HttpStatusCode.INTERNAL_SERVER_ERROR,
                    Data = updateUser
                };
            }
  
        }


        public async Task<IBaseResponse<User>> DeleteUser(int userId)
        {
            try
            {
                var user = await FindUser(userId);

                if (user is null)
                {
                    return new BaseResponse<User>()
                    {
                        Description = $"User with id:{userId} does not exist!",
                        StatusCode = HttpStatusCode.NOT_FOUND,
                    };
                }

                _taskContext.Users.Remove(user);
                await _taskContext.SaveChangesAsync();

                return new BaseResponse<User>()
                {
                    Description = $"User with id{userId} was deleted successfully!",
                    StatusCode = HttpStatusCode.OK
                };
            }

            catch(Exception ex)
            {
                return new BaseResponse<User>()
                {
                    Description = ex.Message,
                    StatusCode = HttpStatusCode.INTERNAL_SERVER_ERROR
                };
            }
            
            
        }

        private async Task<User?> FindUser(int userId)
        {
            return await _taskContext.Users.FindAsync(userId);
        }

        public bool HasAdminRights(User user, params UserRole[] roles)
        {            
            var userRoles = user.Roles.ToList();
            var hasAdminRoles = userRoles.Exists(role => roles.Contains(role.Roles.UserRole));
            return hasAdminRoles;
        }
    }
}
