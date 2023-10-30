using Arc.Facades.Anonymous.Interfaces.Registration;
using Arc.Models.Views.Anonymous.Models;
using Arc.Tests.Base.Extensions;
using Arc.Tests.Integrations.Factories;

using Xunit;

namespace Arc.Tests.Integrations.Tests.Facades.ConfirmEmailFacade;

public sealed class ConfirmEmailFacadeBadDataExceptionTests
{
    [Fact]
    public async Task ExceptionTest()
    {
        var factory =
            new Factory();

        var request =
            new ConfirmEmailRequest(
                "",
                ""
            );

        var facade =
            factory
                .DependencyFactory
                .GetImplementation<IConfirmEmailFacade>();

        await
            facade
                .Execute(
                    request
                )
                .ValidateFail(
                    ErrorCodeConstants.BadData
                );
    }
}