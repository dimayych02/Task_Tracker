using StatusCodeEnum;

namespace Interfaces
{
    public interface IBaseResponse<T>
    {
        HttpStatusCode StatusCode { get; }
        string Description { get; }
        T? Data { get; }
    }
}
