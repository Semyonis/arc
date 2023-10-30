using Microsoft.AspNetCore.Mvc;

namespace Arc.Facades.Domain.Filters.Interfaces;

public interface IErrorResponseFacade
{
    IActionResult CreateErrorResponse(
        Exception exception,
        string traceId
    );
}