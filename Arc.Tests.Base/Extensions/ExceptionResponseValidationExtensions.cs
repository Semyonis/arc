using System.Threading.Tasks;

using Arc.Infrastructure.Exceptions.Models;

using Xunit;

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

            Assert.Fail();
        }
        catch (Exception exception)
        {
            Assert
                .NotNull(
                    exception
                );

            if (exception is not ServerException serverException)
            {
                Assert
                    .Fail(
                        "Wrong exception type"
                    );

                return;
            }

            var errorCode =
                serverException
                    .ExceptionInfo;

            {
                var isContains =
                    errorCode.Code
                    == expectedErrorCode;

                Assert
                    .True(
                        isContains,
                        $"Error codes must contain '{expectedErrorCode}'"
                    );
            }
        }
    }
}