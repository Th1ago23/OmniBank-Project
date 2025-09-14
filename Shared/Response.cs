namespace Shared
{
    public class Response<T>(int statusCode, string message, T data)
    {
        public bool IsSucess => statusCode >= 200 && statusCode < 300;
        public string Message { get; set; } = message;
        public T Data { get; set; } = data;
    }
}
