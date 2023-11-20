using Arc.Infrastructure.ConfigurationSettings.Models;

using Microsoft.Extensions.Configuration;

namespace Arc.Executable.WebApi.Configuration.ServiceCollectionExtensions;

public static class SettingsConfiguration
{
    public static IServiceCollection SetupSettings(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services
            .Configure<JwtSettings>(
                configuration
                    .GetSection(
                        "Jwt"
                    )
            )
            .Configure<RedisStackSettings>(
                configuration
                    .GetSection(
                        "RedisStack"
                    )
            );

        return
            services;
    }
}