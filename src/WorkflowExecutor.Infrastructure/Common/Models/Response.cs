using WorkflowExecutor.Infrastructure.Common.Interfaces;

namespace WorkflowExecutor.Infrastructure.Models;

public static class Response
{
    public static IResponse<T> Fail<T>(string error)
        => new Response<T>(error, false);

    public static IResponse<T> Fail<T>(List<string> errors)
        => new Response<T>(errors, false);

    public static IResponse<T> Success<T>(T data)
        => new Response<T>(data, true);
}

public class Response<T> : IResponse<T>
{
    public Response(string error, bool succeeded)
    {
        Errors = new List<string>
        {
            error
        };
        Succeeded = succeeded;
    }

    public Response(T data, bool succeeded)
    {
        Data = data;
        Errors = new List<string>();
        Succeeded = succeeded;
    }

    public Response(List<string> errors, bool succeeded)
    {
        Errors = errors;
        Succeeded = succeeded;
    }
    public T Data { get; } = default!;
    public List<string> Errors { get; }
    public bool Succeeded { get; }
}