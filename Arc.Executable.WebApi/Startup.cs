using System.Text.Json.Serialization;

using Arc.Executable.WebApi.Configuration.ApplicationBuilderExtensions;
using Arc.Executable.WebApi.Configuration.ServiceCollectionExtensions;
using Arc.Infrastructure.Common.Constants;

using FluentValidation.AspNetCore;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Arc.Executable.WebApi;

public sealed class Startup(IConfiguration
        configuration,
    ILoggerFactory
        loggerFactory)
{
    public void ConfigureServices(
        IServiceCollection services
    )
    {
        //duplicated
        //depends on redis section structure in appconfig
        /*var redisConfiguration =
            _configuration
                .GetSection(
                    "Redis"
                )["ConnectionString"];*/

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
            .AddDistributedMemoryCache()
            /*.AddStackExchangeRedisCache(
                options =>
                {
                    options.Configuration =
                        redisConfiguration;
                }
            )*/
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
            .SetupDependencies()
            .AddControllers();
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