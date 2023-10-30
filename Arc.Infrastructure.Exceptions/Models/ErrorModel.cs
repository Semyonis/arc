// ReSharper disable NotAccessedPositionalProperty.Global

namespace Arc.Infrastructure.Exceptions.Models;

public sealed record ErrorModel(
    string ErrorCode,
    string Description,
    object? Details
);