using Models;
namespace Interfaces
{
    public interface ITaskService
    {
        Task<IBaseResponse<UserTask>> CreateTask(UserTask userTask);
        Task<IBaseResponse<UserTask>> UpdateTask(int userId, int taskId, UserTask userTask);
        Task<IBaseResponse<UserTask>> DeleteTask(int userId, int taskId);
    }
}
