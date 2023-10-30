// ReSharper disable NotAccessedPositionalProperty.Global

namespace Arc.Models.BusinessLogic.Response;

public sealed record ErrorResponse(
    string ErrorCode,
    string Description,
    object? Details
);