using static Arc.Infrastructure.Common.Constants.Database.DatabaseSpecialValueConstants;
using static Arc.Infrastructure.Entity.Expressions.Extensions.Implementations.ServiceModeExpressions;

namespace Arc.Database.Definitions.Implementations;

public sealed class ServiceModeDefinition :
    IEntityTypeConfiguration<ServiceMode>
{
    public void Configure(
        EntityTypeBuilder<ServiceMode> builder
    )
    {
        builder
            .SetProperty(
                GetId(),
                Integer
            );

        builder
            .SetRequiredProperty(
                GetUpdatedById(),
                Integer
            );

        builder
            .SetRequiredProperty(
                GetUpdateDateTime(),
                Timestamp
            )
            .HasDefaultValueSql(
                CurrentTimestamp
            );

        builder
            .SetRequiredProperty(
                GetMode(),
                ModeEnumDefinition
            );

        builder
            .SetKey(
                GetId()
            );
    }
}