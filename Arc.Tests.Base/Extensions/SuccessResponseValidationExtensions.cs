using System.Threading.Tasks;

using Arc.Models.BusinessLogic.Response;

using Xunit;

namespace Arc.Tests.Base.Extensions;

public static class SuccessResponseValidationExtensions
{
    public static async Task<OkResponse> ValidateSuccess(
        this Task<Response> task
    )
    {
        var result =
            await
                task;

        return
            result.ValidateSuccess();
    }

    public static async Task<T> ValidateSuccess<T>(
        this Task<Response> task
    )
    {
        var result =
            await
                task;

        return
            result.ValidateSuccess<T>();
    }

    public static OkResponse ValidateSuccess(
        this Response result
    )
    {
        Assert
            .NotNull(
                result
            );

        var okResponse =
            result as OkResponse;

        Assert
            .NotNull(
                okResponse
            );

        return
            okResponse;
    }

    public static T ValidateSuccess<T>(
        this Response result
    )
    {
        var response =
            result.ValidateSuccess();

        Assert
            .NotNull(
                response.Data
            );

        var isCorrectType =
            response.Data is T;

        Assert
            .True(
                isCorrectType,
                "Response must be " + nameof(T)
            );

        return
            (T)response.Data;
    }
}