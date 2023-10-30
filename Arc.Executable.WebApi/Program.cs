using Arc.Executable.WebApi.Configuration.WebHostBuilderExtensions;

using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Arc.Executable.WebApi;

public static class Program
{
    public static void Main(
        string[] args
    ) =>
        CreateWebHostBuilder(
                args
            )
            .Build()
            .Run();

    // important to keep this function because without it visual studio rejects to create ef migrations by 'add-migration' command 
    private static IWebHostBuilder CreateWebHostBuilder(
        string[] args
    ) =>
        WebHost
            .CreateDefaultBuilder(
                args
            )
            .UseStartup<Startup>()
            .SetupLogs();
}