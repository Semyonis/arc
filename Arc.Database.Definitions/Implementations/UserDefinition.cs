namespace Arc.Database.Definitions.Implementations;

public sealed class UserDefinition :
    IEntityTypeConfiguration<User>
{
    public void Configure(
        EntityTypeBuilder<User> builder
    ) { }
}