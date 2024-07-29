using Interfaces;
using StatusCodeEnum;

namespace Implementations

{
    public class BaseResponse<T> : IBaseResponse<T>
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Description { get; set; }
        public T? Data { get; set; }
    }
}
