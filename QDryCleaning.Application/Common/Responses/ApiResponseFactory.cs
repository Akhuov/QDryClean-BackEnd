using static System.Runtime.InteropServices.JavaScript.JSType;

namespace QDryClean.Application.Common.Responses
{
    public static class ApiResponseFactory
    {
        public static ApiResponse<T> Ok<T>(T data, string message = "Success")
            => new() { Code = 0, Message = message, Response = data };

        public static ApiResponse<T> Fail<T>(int code, string message)
            => new() { Code = code, Message = message, Response = default };
    }
}
