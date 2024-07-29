using Contexts;
using Interfaces;
using Models;
using RoleEnum;
using StatusCodeEnum;

namespace Implementations
{
    public class TaskService : ITaskService
    {

        private readonly  TaskContext _taskContext;

        private readonly IUserService _userService;

        public TaskService(TaskContext taskContext, IUserService userService)
        {
            _taskContext = taskContext;
            _userService = userService;

        }


        public async Task<IBaseResponse<List<UserTask>>> GetUserTasks(int userId)
        {
            try
            {
                var user = await _taskContext.Executors.FindAsync(userId);
                var userTasks = user.ExecutorTasks.ToList();

                return new BaseResponse<List<UserTask>>()
                {
                    StatusCode = HttpStatusCode.OK,
                    Description = $"Tasks to user with id{userId} was founded successfully!",
                    Data = userTasks,
                };
            }

            catch(Exception ex)
            {
                return new BaseResponse<List<UserTask>>()
                {
                    StatusCode = HttpStatusCode.INTERNAL_SERVER_ERROR,
                    Description = ex.Message
                };
            }
          
        }

        public async Task<IBaseResponse<UserTask>> CreateTask(UserTask userTask)
        {
            try
            {
                await _taskContext.Tasks.AddAsync(userTask);
                await _taskContext.SaveChangesAsync();

                return new BaseResponse<UserTask>()
                {
                    Description = $"Task with id{userTask.TaskId} was created succesfully!",
                    StatusCode = HttpStatusCode.CREATED,
                };
            }

            catch (Exception ex)
            {
                return new BaseResponse<UserTask>()
                {
                    Description = ex.Message,
                    StatusCode = HttpStatusCode.INTERNAL_SERVER_ERROR,
                    Data = userTask
                };
            }
        }

        public async Task<IBaseResponse<UserTask>> UpdateTask(int userId, int taskId, UserTask updateUserTask)
        {
            try
            {
                var response = await _userService.GetUser(userId);
                var user = response.Data;

                var hasAdminRights = _userService.HasAdminRights(
                    user,
                    UserRole.АДМИНИСТРАТОР,
                    UserRole.ОТВЕТСТВЕННЫЙ,
                    UserRole.ВЕДУЩИЙ,
                    UserRole.МЕНЕДЖЕР
                );

          

                if (hasAdminRights)
                {
                    var task = await FindTask(taskId);
                    task = updateUserTask;
                    await _taskContext.SaveChangesAsync();

                    return new BaseResponse<UserTask>()
                    {
                        Description = $"Task with id:{taskId} was updated successfully!",
                        StatusCode = HttpStatusCode.OK,
                        Data = updateUserTask
                    };
                }

                else
                {
                    return new BaseResponse<UserTask>()
                    {
                        Description = $"User with id:{userId} does not has rights to update Task!",
                        StatusCode = HttpStatusCode.UNAUTHORIZED
                    };
                }
            }

            catch(Exception ex)
            {
                return new BaseResponse<UserTask>()
                {
                    Description = ex.Message,
                    StatusCode = HttpStatusCode.INTERNAL_SERVER_ERROR
                };
            }
        }

        public async Task<IBaseResponse<UserTask>> DeleteTask(int userId, int taskId)
        {
            try
            {
                var response = await _userService.GetUser(userId);
                var user = response.Data;

                var hasAdminRights = _userService.HasAdminRights(
                    user,
                    UserRole.АДМИНИСТРАТОР,
                    UserRole.ОТВЕТСТВЕННЫЙ 
                );

                if (hasAdminRights)
                {
                    var taskToDelete = await _taskContext.Tasks.FindAsync(taskId);

                    _taskContext.Tasks.Remove(taskToDelete);
                    await _taskContext.SaveChangesAsync();

                    return new BaseResponse<UserTask>()
                    {
                        Description = $"Task with id:{taskId} was deleted successfully!",
                        StatusCode = HttpStatusCode.OK,
                    };
                }

                else
                {
                    return new BaseResponse<UserTask>()
                    {
                        Description = $"User with id:{userId} does not has rights to delete Task!",
                        StatusCode = HttpStatusCode.UNAUTHORIZED
                    };
                }
            }

            catch (Exception ex)
            {
                return new BaseResponse<UserTask>()
                {
                    Description = ex.Message,
                    StatusCode = HttpStatusCode.INTERNAL_SERVER_ERROR
                };
            }
        }

        private async Task<UserTask?> FindTask(int taskId)
        {
            return await _taskContext.Tasks.FindAsync(taskId);
        }
    }
}
