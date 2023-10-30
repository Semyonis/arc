using Microsoft.AspNetCore.Builder;

namespace Arc.Executable.WebApi.Configuration.ApplicationBuilderExtensions;

public static class Controllers
{
    public static void SetupControllers(
        this IApplicationBuilder builder
    )
    {
        builder
            .UseEndpoints(
                endpoints =>
                    endpoints.MapControllers()
            );
    }
}