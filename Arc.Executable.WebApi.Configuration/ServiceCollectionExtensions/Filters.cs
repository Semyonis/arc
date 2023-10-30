using Arc.Middleware.Filters.Implementations;

namespace Arc.Executable.WebApi.Configuration.ServiceCollectionExtensions;

public static class Filters
{
    public static IMvcBuilder SetupFilters(
        this IServiceCollection services
    ) =>
        services
            .AddControllersWithViews(
                options =>
                {
                    options.Filters.Add(
                        typeof(ValidateUserAccessFilter)
                    );

                    options.Filters.Add(
                        typeof(StringNormalizationFilter)
                    );

                    options.Filters.Add(
                        typeof(ExceptionFilter)
                    );
                }
            );
}