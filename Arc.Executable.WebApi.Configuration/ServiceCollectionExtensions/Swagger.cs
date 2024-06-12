using Arc.Infrastructure.Common.Constants.Database;
using Arc.Infrastructure.Common.Extensions;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.Configuration;

using NSwag;
using NSwag.Generation.AspNetCore;
using NSwag.Generation.Processors;
using NSwag.Generation.Processors.Contexts;
using NSwag.Generation.Processors.Security;

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
            "Arc";
        
        return
            services
                .AddOpenApiDocument(
                    options =>
                    {
                        options
                            .Title = Title;
                        
                        options
                            .Version = Version;
                        
                        options
                            .AddSecurity(
                                "Bearer",
                                new()
                                {
                                    Type = OpenApiSecuritySchemeType.Http,
                                    Scheme = JwtBearerDefaults.AuthenticationScheme,
                                    BearerFormat = "JWT",
                                    Description = "Type into the textbox: {your JWT token}.",
                                }
                            );
                        
                        options
                            .OperationProcessors
                            .Add(
                                new AspNetCoreOperationSecurityScopeProcessor(
                                    "Bearer"
                                )
                            );
                        
                        options
                            .OperationProcessors
                            .Add(
                                new CustomTagByOperationProcessor()
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
            builder
                .UseOpenApi()
                .UseSwaggerUI(
                    options =>
                    {
                        options.SwaggerEndpoint(
                            "/swagger/v1/swagger.json",
                            "Arc API V1"
                        );
                        
                        options.RoutePrefix =
                            string.Empty;
                    }
                );
        }
    }
    
    private class CustomTagByOperationProcessor :
        IOperationProcessor
    {
        public bool Process(
            OperationProcessorContext context
        )
        {
            if (context is not AspNetCoreOperationProcessorContext aspNetCoreContext)
            {
                return true;
            }
            
            var tags =
                aspNetCoreContext
                    .OperationDescription
                    .Operation
                    .Tags;
            
            var groupName =
                aspNetCoreContext
                    .ApiDescription
                    .GroupName;
            
            var isEmptyGroupName =
                groupName != null;
            
            if (isEmptyGroupName)
            {
                tags
                    .Add(
                        groupName
                    );
                
                return true;
            }
            
            var actionDescriptor =
                aspNetCoreContext
                    .ApiDescription
                    .ActionDescriptor;
            
            if (actionDescriptor is not ControllerActionDescriptor
                controllerActionDescriptor)
            {
                throw new InvalidOperationException(
                    "Unable to determine tag for endpoint."
                );
            }
            
            var controllerName =
                controllerActionDescriptor.ControllerName;
            
            tags
                .Add(
                    controllerName
                );
            
            return true;
        }
    }
}