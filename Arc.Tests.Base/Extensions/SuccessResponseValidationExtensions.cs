using System.Threading.Tasks;

using Arc.Models.BusinessLogic.Response;

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
        result
            .Should()
            .NotBeNull();

        var exceptionMessage =
            GetResponseMustBeOfTypeExceptionMessage<OkResponse>();

        var resultContainer =
            result
                .Should()
                .BeOfType<OkResponse>(
                    exceptionMessage
                );

        var containerSubject =
            resultContainer
            .Subject;

        containerSubject
            .Should()
            .NotBeNull();

        return
            containerSubject;
    }

    public static T ValidateSuccess<T>(
        this Response result
    )
    {
        var response =
            result.ValidateSuccess();

        response
            .Data
            .Should()
            .NotBeNull();

        var exceptionMessage =
            GetResponseMustBeOfTypeExceptionMessage<T>();

        var resultContainer =
            response
                .Data
                .Should()
                .BeOfType<T>(
                    exceptionMessage
                );

        return
            resultContainer.Subject;
    }

    private static string GetResponseMustBeOfTypeExceptionMessage<T>() =>
        $"Response must be of type {nameof(T)}";
}