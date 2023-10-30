using Arc.Infrastructure.Common.Constants.Database;
using Arc.Infrastructure.Common.Extensions;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;

namespace Arc.Executable.WebApi.Configuration.ServiceCollectionExtensions;

public static class Swagger
{
    public static IServiceCollection SetupSwagger(
        this IServiceCollection services
    )
    {
        const string Version =
            "v1";

        const string Title =
            "ArcDX";

        return
            services
                .AddSwaggerGen(
                    options =>
                    {
                        options
                            .SwaggerDoc(
                                Version,
                                new()
                                {
                                    Title = Title,
                                    Version = Version,
                                }
                            );

                        options
                            .TagActionsBy(
                                api =>
                                {
                                    if (api.GroupName != null)
                                    {
                                        return new[]
                                        {
                                            api.GroupName,
                                        };
                                    }

                                    if (api.ActionDescriptor is
                                        ControllerActionDescriptor
                                        controllerActionDescriptor)
                                    {
                                        return new[]
                                        {
                                            controllerActionDescriptor
                                                .ControllerName,
                                        };
                                    }

                                    throw new InvalidOperationException(
                                        "Unable to determine tag for endpoint."
                                    );
                                }
                            );

                        options
                            .DocInclusionPredicate(
                                (
                                    _,
                                    _
                                ) => true
                            );

                        //option 2: authorization button to enter the token once
                        options
                            .AddSecurityDefinition(
                                "Bearer",
                                new()
                                {
                                    In = ParameterLocation.Header,
                                    Description =
                                        "Please insert JWT with Bearer into field",
                                    Name = "Authorization",
                                    Type = SecuritySchemeType.ApiKey,
                                }
                            );

                        options
                            .AddSecurityRequirement(
                                new()
                                {
                                    {
                                        new()
                                        {
                                            Reference =
                                                new()
                                                {
                                                    Id = "Bearer",
                                                    Type = ReferenceType.SecurityScheme,
                                                },
                                            Scheme = "oauth2",
                                            Name = "Bearer",
                                            In = ParameterLocation.Header,
                                        },
                                        new List<string>()
                                    },
                                }
                            );
                    }
                );
    }

    public static void RegisterSwagger(
        this IApplicationBuilder builder,
        IConfiguration configuration
    )
    {
        var statusSwagger =
            configuration[DatabaseSettingsConstants.DisableSwagger]
            ?? "false";

        var isFalse =
            statusSwagger
                .IsEqualTo(
                    "false"
                );

        if (isFalse)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            builder
                .UseSwagger(
                    options =>
                    {
                        options
                            .PreSerializeFilters
                            .Add(
                                (
                                    swagger,
                                    httpReq
                                ) =>
                                {
                                    swagger.Servers =
                                        new List<OpenApiServer>
                                        {
                                            new()
                                            {
                                                Url = $"https://{httpReq.Host}",
                                            },
                                        };
                                }
                            );
                    }
                );

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            builder
                .UseSwaggerUI(
                    options =>
                    {
                        options.DisplayRequestDuration();

                        options
                            .SwaggerEndpoint(
                                "/swagger/v1/swagger.json",
                                "Arc Api V1"
                            );

                        options.RoutePrefix =
                            string.Empty;
                    }
                );
        }
    }
}