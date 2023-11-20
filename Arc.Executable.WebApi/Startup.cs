using System.Net;
using System.Text.Json.Serialization;

using Arc.Executable.WebApi.Configuration.ApplicationBuilderExtensions;
using Arc.Executable.WebApi.Configuration.ServiceCollectionExtensions;
using Arc.Infrastructure.Common.Constants;
using Arc.Infrastructure.Common.Extensions;

using FluentValidation.AspNetCore;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using StackExchange.Redis;

namespace Arc.Executable.WebApi;

public sealed class Startup(
    IConfiguration
        configuration,
    ILoggerFactory
        loggerFactory
)
{
    public void ConfigureServices(
        IServiceCollection services
    )
    {
        services
            .SetupIdentity()
            .SetupAuthentication(
                configuration
            )
            .SetupCors(
                configuration
            )
            .Configure<ForwardedHeadersOptions>(
                options =>
                {
                    options.ForwardedHeaders =
                        ForwardedHeaders.XForwardedFor
                        | ForwardedHeaders.XForwardedProto;

                    options.ForwardLimit = 2;
                }
            )
            .SetupSwagger()
            .SetupContext(
                loggerFactory,
                configuration
            )
            .SetupSettings(
                configuration
            )
            .SetupFilters()
            .AddJsonOptions(
                options =>
                {
                    var jsonStringEnumConverter =
                        new JsonStringEnumConverter(
                            default,
                            false
                        );

                    options
                        .JsonSerializerOptions
                        .Converters
                        .Add(
                            jsonStringEnumConverter
                        );
                }
            );

        services.AddFluentValidationAutoValidation();
        services.AddFluentValidationClientsideAdapters();

        services
            .SetupDependencies();

        var redisStackConfigurationOptions =
                GetRedisStackConfigurationOptions(
                    configuration
                );

        services
            .AddStackExchangeRedisCache(
                options =>
                    options.ConfigurationOptions =
                        redisStackConfigurationOptions
            )
            .AddControllers();
    }

    private static ConfigurationOptions GetRedisStackConfigurationOptions(
        IConfiguration configuration
    )
    {
        var redisHost =
            configuration
                .GetSection(
                    "RedisStack"
                )["Host"]!;

        var redisPort =
            configuration
                .GetSection(
                    "RedisStack"
                )["Port"]!;

        var port =
            redisPort
                .ParseToNullableInteger()!
                .Value;

        var dnsEndPoint =
            new DnsEndPoint(
                redisHost,
                port
            );

        var endpoints =
            (dnsEndPoint as EndPoint).WrapByList();

        var endPointCollection =
            new EndPointCollection(
                endpoints
            );

        return 
            new()
            {
                EndPoints =
                    endPointCollection,
            };
    }

    public void Configure(
        IApplicationBuilder builder,
        IWebHostEnvironment environment
    )
    {
        if (environment.IsDevelopment())
        {
            builder.UseDeveloperExceptionPage();
        }

        builder
            .UseCors(
                CorsPolicyConstants.DefaultCorsPolicy
            );

        builder
            .RegisterSwagger(
                configuration
            );

        builder.UseWebSockets();
        builder.UseRouting();
        builder.UseAuthentication();
        builder.UseAuthorization();
        builder.SetupControllers();
    }
}