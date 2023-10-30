namespace Arc.Infrastructure.Exceptions.Models;

public sealed class ExceptionInfo
{
    public ExceptionInfo(
        string code,
        object? details = default
    )
    {
        Code = code;
        Details = details;
    }

    public string Code { get; }

    public object? Details { get; }
}