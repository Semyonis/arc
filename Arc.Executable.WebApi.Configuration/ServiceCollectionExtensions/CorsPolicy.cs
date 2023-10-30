using Arc.Infrastructure.Common.Constants;

using Microsoft.Extensions.Configuration;

namespace Arc.Executable.WebApi.Configuration.ServiceCollectionExtensions;

public static class CorsPolicy
{
    public static IServiceCollection SetupCors(
        this IServiceCollection services,
        IConfiguration configuration
    ) =>
        services
            .AddCors(
                options =>
                {
                    var corsOrigins =
                        configuration.GetCorsOrigins();

                    options
                        .AddPolicy(
                            CorsPolicyConstants.DefaultCorsPolicy,
                            builder =>
                                builder
                                    .WithOrigins(
                                        corsOrigins
                                    )
                                    .AllowAnyHeader()
                                    .AllowAnyMethod()
                                    .AllowCredentials()
                                    .SetPreflightMaxAge(
                                        TimeSpan.FromSeconds(
                                            86400
                                        )
                                    )
                        );
                }
            );

    private static string[] GetCorsOrigins(
        this IConfiguration configuration
    ) =>
        configuration[CorsPolicyConstants.CorsOrigins]
            ?
            .Split(
                ','
            )
        ?? new[]
        {
            "localhost",
        };
}