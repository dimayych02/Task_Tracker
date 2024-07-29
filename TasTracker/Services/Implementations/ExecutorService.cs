using Contexts;
using Interfaces;
using Models;

namespace Implementations
{
    public class ExecutorService : IExecutorService

    {
        private readonly TaskContext _taskContext;

        public ExecutorService(TaskContext taskContext)
        {
            _taskContext = taskContext;
        }

        public async Task<IBaseResponse<Executor?>> GetExecutor(int executorId)
        {
            try
            {
                var executor = await FindExecutor(executorId);

                return new BaseResponse<Executor?>()
                {
                    Data = executor,
                    StatusCode = StatusCodeEnum.HttpStatusCode.OK
                };
            }

            catch(Exception ex)
            {
                return new BaseResponse<Executor?>()
                {
                    Description = ex.Message
                };
            }
        }

        public async Task<IBaseResponse<Executor>> CreateExecutor(Executor executor)
        {
            try
            {
                await _taskContext.AddAsync(executor);
                await _taskContext.SaveChangesAsync();

                return new BaseResponse<Executor>()
                {
                    Description =  "Executor was created successfully!",
                    Data = executor,
                    StatusCode = StatusCodeEnum.HttpStatusCode.CREATED,
                };
            }

            catch(Exception ex)
            {
                return new BaseResponse<Executor>()
                {
                    Description = ex.Message,
                    Data = executor,
                    StatusCode = StatusCodeEnum.HttpStatusCode.INTERNAL_SERVER_ERROR
                };
            }
        }

        public async Task<IBaseResponse<Executor>> UpdateExecutor(int executorId, Executor executorUpdate)
        {
            try
            {
                var executor = await FindExecutor(executorId);
                executor = executorUpdate;
                await _taskContext.SaveChangesAsync();

                if(executor is null)
                {
                    return new BaseResponse<Executor>()
                    {
                        Description = $"Executor with id{executorId} does not exist!",
                        StatusCode = StatusCodeEnum.HttpStatusCode.NOT_FOUND
                    };
                }

                return new BaseResponse<Executor>()
                {
                    Description = $"Executor with id{executorId} was update Successfully!",
                    Data = executor,
                    StatusCode = StatusCodeEnum.HttpStatusCode.OK
                };


            }
            
            catch(Exception ex)
            {
                return new BaseResponse<Executor>()
                {
                    Description = ex.Message,
                    Data = executorUpdate,
                    StatusCode = StatusCodeEnum.HttpStatusCode.INTERNAL_SERVER_ERROR
                };
            }
        }

        public async Task<IBaseResponse<Executor>> DeleteExecutor(int executorId)
        {
            try
            {
                var executor = await FindExecutor(executorId);

                if(executor is null)
                {
                    return new BaseResponse<Executor>
                    {
                        Description = $"Executor with id:{executorId} does not exist",
                        StatusCode = StatusCodeEnum.HttpStatusCode.NOT_FOUND
                    };
                }

                return new BaseResponse<Executor>
                {
                    Description = $"Executor with id:{executorId} was deleted successfully!",
                    Data = executor,
                    StatusCode = StatusCodeEnum.HttpStatusCode.OK
                };
            } 

            catch(Exception ex)
            {
                return new BaseResponse<Executor>
                {
                    Description = ex.Message,
                    StatusCode = StatusCodeEnum.HttpStatusCode.INTERNAL_SERVER_ERROR
                };
            }
        }

        private async Task<Executor?> FindExecutor(int executorId)
        {
            return await _taskContext.Executors.FindAsync(executorId);
        }
    }

   
}
