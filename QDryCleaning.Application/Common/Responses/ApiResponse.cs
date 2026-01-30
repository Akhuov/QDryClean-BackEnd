using System.Text.Json.Serialization;

namespace QDryClean.Application.Common.Responses
{
    public class ApiResponse<T>
    {
        public int Code { get; init; }
        public string Message { get; init; } = string.Empty;
        public T? Response { get; init; }

        [JsonIgnore]
        public bool IsSuccess => Code == 0;
    }
}
