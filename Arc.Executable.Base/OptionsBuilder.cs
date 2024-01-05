using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Arc.Executable.Base;

public sealed class OptionsBuilder
{
   public IOptions<TEntity> Build<TEntity>(
        TEntity settings,
        string section
    )
        where TEntity : class
    {
        var configuration =
            new ConfigurationBuilder()
                .Build();

        configuration
            .GetSection(
                section
            )
            .Bind(
                settings
            );

        return
            Options
                .Create(
                    settings
                );
    }
}