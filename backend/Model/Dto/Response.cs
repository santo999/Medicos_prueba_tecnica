using System.Text.Json.Serialization;

namespace backend.Model.Dto
{
    public class Response<T>
    {
        public bool Resp { get; set; } = true;

        public string Message { get; set; } = string.Empty;

        public T? Data { get; set; }

        [JsonIgnore]
        public int StatusCode { get; set; } = StatusCodes.Status200OK;

        public static Response<T> Success(T data, string message = "", int statusCode = StatusCodes.Status200OK) =>
            new() { Resp = true, Message = message, Data = data, StatusCode = statusCode };

        public static Response<T> Fail(string message, int statusCode) =>
            new() { Resp = false, Message = message, StatusCode = statusCode };
    }
}
