using System.Net;
using System.Text.Json.Serialization;

using Arc.Executable.WebApi.Configuration.ApplicationBuilderExtensions;
using Arc.Executable.WebApi.Configuration.ServiceCollectionExtensions;
using Arc.Infrastructure.Common.Constants;
using Arc.Infrastructure.Common.Extensions;

using FluentValidation.AspNetCore;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using StackExchange.Redis;

var builder =
    WebApplication
        .CreateBuilder(
            args
        );

ConfigureBuilder(
    builder
);

var webApplication =
    builder.Build();

ConfigureWebApplication(
    webApplication
);

webApplication.Run();

return;

void ConfigureBuilder(
    WebApplicationBuilder webApplicationBuilder
)
{
    var configuration =
        webApplicationBuilder.Configuration;

    var redisStackConfigurationOptions =
        GetRedisStackConfigurationOptions(
            configuration
        );

    webApplicationBuilder
        .Services
        .SetupIdentity()
        .SetupAuthentication(
            configuration
        )
        .SetupCors(
            configuration
        )
        .SetupSwagger()
        .SetupContext(
            configuration
        )
        .SetupSettings(
            configuration
        )
        .AddFluentValidationAutoValidation()
        .AddFluentValidationClientsideAdapters()
        .SetupDependencies()
        .AddStackExchangeRedisCache(
            options =>
                options.ConfigurationOptions =
                    redisStackConfigurationOptions
        )
        .SetupFilters()
        .AddControllers()
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

    webApplicationBuilder
        .Host
        .UseDefaultServiceProvider(
            serviceProviderOptions =>
            {
                serviceProviderOptions.ValidateOnBuild = false;
                serviceProviderOptions.ValidateScopes = true;
            }
        );
}

void ConfigureWebApplication(
    WebApplication webApplication1
)
{
    if (webApplication1.Environment.IsDevelopment())
    {
        webApplication1.UseDeveloperExceptionPage();
    }

    webApplication1
        .UseCors(
            CorsPolicyConstants.DefaultCorsPolicy
        );

    webApplication1
        .RegisterSwagger(
            webApplication1.Configuration
        );

    webApplication1.UseWebSockets();
    webApplication1.UseRouting();
    webApplication1.UseAuthentication();
    webApplication1.UseAuthorization();
    webApplication1.SetupControllers();
}

ConfigurationOptions GetRedisStackConfigurationOptions(
    IConfiguration configurationManager
)
{
    var redisHost =
        configurationManager
            .GetSection(
                "RedisStack"
            )["Host"]!;

    var redisPort =
        configurationManager
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
