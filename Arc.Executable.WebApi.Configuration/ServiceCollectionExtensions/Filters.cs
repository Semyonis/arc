using Arc.Middleware.Filters.Implementations;

namespace Arc.Executable.WebApi.Configuration.ServiceCollectionExtensions;

public static class Filters
{
    public static IServiceCollection SetupFilters(
        this IServiceCollection services
    )
    {
        var filters =
            new[]
            {
                typeof(InitiateArcIdentityFilter),
                typeof(ValidateUserAccessFilter),
                typeof(StringNormalizationFilter),
                typeof(ExceptionFilter),
            };

        services
            .AddControllersWithViews(
                options =>
                {
                    foreach (var filter in filters)
                    {
                        options
                            .Filters
                            .Add(
                                filter
                            );
                    }
                }
            );

        return
            services;
    }
}