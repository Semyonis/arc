using System.Threading.Tasks;

using Arc.Infrastructure.Exceptions.Models;

namespace Arc.Tests.Base.Extensions;

public static class ExceptionResponseValidationExtensions
{
    public static async Task ValidateFail(
        this Task task,
        string expectedErrorCode
    )
    {
        try
        {
            await
                task;

            throw new();
        }
        catch (Exception exception)
        {
            exception
                .Should()
                .NotBeNull();

            var container =
                exception
                    .Should()
                    .BeOfType<ServerException>();

            var serverException =
                container.Subject;
                
            var errorCode =
                serverException.ExceptionInfo.Code;

            errorCode
                .Should()
                .Be(
                    expectedErrorCode,
                    $"Error codes must contain '{expectedErrorCode}'"
                );
        }
    }
}