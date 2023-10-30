using static Arc.Infrastructure.Entity.Expressions.Extensions.Implementations.GroupExpressions;

namespace Arc.Database.Definitions.Implementations;

public sealed class GroupDefinition :
    IEntityTypeConfiguration<Group>
{
    public void Configure(
        EntityTypeBuilder<Group> builder
    )
    {
        builder
            .SetProperty(
                GetId(),
                Integer
            );

        builder
            .SetRequiredProperty(
                GetDescriptionId(),
                Integer
            );

        builder
            .SetRequiredProperty(
                GetName(),
                String256
            );

        builder
            .SetKey(
                GetId()
            );

        builder
            .SetUniqueIndex(
                GetDescriptionId()
            );

        builder
            .SetOneToOneNavigation(
                GetDescription(),
                GroupDescriptionExpressions.GetGroup(),
                GetDescriptionId()
            );
    }
}