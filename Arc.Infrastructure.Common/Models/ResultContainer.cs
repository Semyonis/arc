using System.Diagnostics.CodeAnalysis;

namespace Arc.Infrastructure.Common.Models;

public sealed record ResultContainer<T>
{
    private ResultContainer(
        string errorDetails = ""
    )
    {
        IsSuccess = false;
        Value = default;
        ErrorDetails = errorDetails;
    }

    private ResultContainer(
        bool isSuccess,
        T value
    )
    {
        IsSuccess = isSuccess;
        Value = value;
        ErrorDetails = "";
    }

    [MemberNotNullWhen(
        true,
        nameof(Value)
    )]
    public bool IsSuccess { get; }

    public T? Value { get; }

    public string ErrorDetails { get; }

    public static ResultContainer<T> GetFailed(
        string errorDetails = ""
    ) =>
        new(
            errorDetails
        );

    public static ResultContainer<T> GetSuccessful(
        T value
    ) =>
        new(
            true,
            value
        );
}