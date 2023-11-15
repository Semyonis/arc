namespace Arc.Infrastructure.Exceptions.Models;

public sealed class ExceptionInfo(string code,
    object? details = default)
{
    public string Code { get; } = code;

    public object? Details { get; } = details;
}