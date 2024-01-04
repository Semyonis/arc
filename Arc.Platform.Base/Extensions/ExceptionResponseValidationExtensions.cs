using System.Threading.Tasks;

using Arc.Infrastructure.Exceptions.Models;

using Xunit;

namespace Arc.Platform.Base.Extensions;

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