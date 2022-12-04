using System.Text.Json.Serialization;

namespace Enigmatry.Shop.Models.Extensions;

public static class ApiResponse
{
    public static Response<T> Fail<T>(T data, string message)
    {
        return new Response<T>(data, false, message);
    }

    public static Response<T> Ok<T>(T data)
    {
        return new Response<T>(data, true, "");
    }
}

public class Response<T>
{
    public T Data { get; set; }
    public bool Success { get; set; }
    public string Message { get; set; }

    public Response(T data, bool success, string message)
    {
        Data = data;
        Success = success;
        Message = message;
    }
}