using Contexts;
using Interfaces;
using Models;

namespace Implementations
{
    public class RoleService : IRoleService
    {
        private readonly TaskContext _taskContext;

        public RoleService(TaskContext taskContext)
        {
            _taskContext = taskContext;
        }

        public async Task<IBaseResponse<Roles>> GetRole(int roleId)
        {
            var role = await FindRole(roleId);

            if (role is null)
            {
                return new BaseResponse<Roles>()
                {
                    Description = $"Role with id:{roleId} does not exist!",
                    StatusCode = StatusCodeEnum.HttpStatusCode.NOT_FOUND
                };

            }
            return new BaseResponse<Roles>()
            {
                Description = $"Role with id:{roleId} was founded!",
                Data = role,
                StatusCode = StatusCodeEnum.HttpStatusCode.OK
            };
        }

        public async Task<IBaseResponse<Roles>> CreateRole(Roles role)
        {
            try
            {
                await _taskContext.AddAsync(role);
                await _taskContext.SaveChangesAsync();

                return new BaseResponse<Roles>()
                {
                    Description = "Role was created successfully!",
                    Data = role,
                    StatusCode = StatusCodeEnum.HttpStatusCode.CREATED
                };
            }

            catch (Exception ex)
            {
                return new BaseResponse<Roles>()
                {
                    Description = ex.Message,
                    Data = role,
                    StatusCode = StatusCodeEnum.HttpStatusCode.INTERNAL_SERVER_ERROR
                };
            }
        }

            public async Task<IBaseResponse<Roles>> UpdateRole(int roleId, Roles updateRole)
            {
                try
                {
                    var role = await FindRole(roleId);
                    role = updateRole;
                    await _taskContext.SaveChangesAsync();

                    return new BaseResponse<Roles>()
                    {
                        Description = $"Role with id:{roleId} was updated successfully!",
                        Data = role,
                        StatusCode = StatusCodeEnum.HttpStatusCode.OK
                    };
                }

                catch (Exception ex)
                {
                    return new BaseResponse<Roles>()
                    {
                        Description = ex.Message,
                        Data = updateRole,
                        StatusCode = StatusCodeEnum.HttpStatusCode.INTERNAL_SERVER_ERROR
                    };
                }
            }

        public async Task<IBaseResponse<Roles>> DeleteRole(int roleId)
        {
            try
            {
                var role = await FindRole(roleId);
                _taskContext.Remove(role);
                await _taskContext.SaveChangesAsync();

                return new BaseResponse<Roles>()
                {
                    Description = $"Role with id:{roleId} was deleted successfully!",
                    Data = role,
                    StatusCode = StatusCodeEnum.HttpStatusCode.OK
                };
            }

            catch (Exception ex)
            {
                return new BaseResponse<Roles>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCodeEnum.HttpStatusCode.INTERNAL_SERVER_ERROR
                };
            }
        }
        

        private async Task<Roles?> FindRole(int roleId)
        {
            return await _taskContext.Roles.FindAsync(roleId);
        }
    }
}
