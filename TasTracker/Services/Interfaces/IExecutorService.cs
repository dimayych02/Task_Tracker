using Models;

namespace Interfaces
{
    public interface IExecutorService
    {
        Task<IBaseResponse<Executor>> GetExecutor(int executorId);
        Task<IBaseResponse<Executor>> CreateExecutor(Executor executor);
        Task<IBaseResponse<Executor>> UpdateExecutor(int executorId, Executor executor);
        Task<IBaseResponse<Executor>> DeleteExecutor(int executorId);
    }
}
