using static Arc.Infrastructure.Entity.Expressions.Extensions.Implementations.ComplexPropertyExpressions;

namespace Arc.Database.Definitions.Implementations;

public sealed class ComplexPropertyDefinition :
    IEntityTypeConfiguration<ComplexProperty>
{
    public void Configure(
        EntityTypeBuilder<ComplexProperty> builder
    )
    {
        builder
            .SetProperty(
                GetId(),
                Integer
            );

        builder
            .SetRequiredProperty(
                GetGroupId(),
                Integer
            );

        builder
            .SetRequiredProperty(
                GetDescriptionId(),
                Integer
            );

        builder
            .SetRequiredProperty(
                GetValue(),
                String128
            );

        builder
            .SetKey(
                GetId()
            );

        builder
            .SetUniqueIndex(
                GetValue()
            );

        builder
            .SetUniqueIndex(
                GetGroupId()
            );

        builder
            .SetUniqueIndex(
                GetDescriptionId()
            );

        builder
            .SetOneToOneNavigation(
                GetDescription(),
                ComplexPropertyDescriptionExpressions.GetComplexProperty(),
                GetDescriptionId()
            );

        builder
            .SetOneToManyNavigation(
                GetGroup(),
                GroupExpressions.GetComplexProperties(),
                GetGroupId()
            );
    }
}