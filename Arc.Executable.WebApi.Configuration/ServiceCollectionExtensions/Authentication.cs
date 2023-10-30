using System.Text;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Arc.Executable.WebApi.Configuration.ServiceCollectionExtensions;

public static class Authentication
{
    public static IServiceCollection SetupAuthentication(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services
            .AddAuthentication(
                option =>
                {
                    option.DefaultAuthenticateScheme =
                        JwtBearerDefaults.AuthenticationScheme;

                    option.DefaultChallengeScheme =
                        JwtBearerDefaults.AuthenticationScheme;

                    option.DefaultScheme =
                        JwtBearerDefaults.AuthenticationScheme;

                    option.DefaultSignInScheme =
                        IdentityConstants.ExternalScheme;
                }
            )
            .AddJwtBearer(
                options =>
                {
                    options.SaveToken = true;
                    options.RequireHttpsMetadata = true;

                    options.TokenValidationParameters =
                        new()
                        {
                            ValidateIssuer = true,
                            ValidateAudience = true,
                            ValidAudience = configuration["Jwt:Site"],
                            ValidIssuer = configuration["Jwt:Site"],
                            IssuerSigningKey =
                                new SymmetricSecurityKey(
                                    Encoding.UTF8.GetBytes(
                                        configuration["Jwt:SigningKey"]
                                        ?? "signing_key"
                                    )
                                ),
                            ValidateIssuerSigningKey = true,
                            ValidateLifetime = true,
                            ClockSkew = TimeSpan.Zero,
                        };
                }
            );

        return services;
    }
}