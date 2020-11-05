using Twitter.Domain.Communication;
using Twitter.Resources;
using Twitter.Resources.Communication;

namespace Twitter.Extensions
{
    public static class BaseResponseExtention
    {
        public static ResponseResult GetResponseResult<T>(this T response, IResource resource) where T : BaseResponse
        {
            return new ResponseResult
            {
                Data = resource,
                Message = response.Message,
                Success = response.Success
            };
        }
    }
}