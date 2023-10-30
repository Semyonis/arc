using Arc.Models.Views.Admins.Tables.Models.Groups;

namespace Arc.Dependencies.RequestValidators.Implementations.Groups;

public sealed class GroupsTableUpdateValidator :
    AbstractValidator<GroupTableUpdateRequest>
{
    public GroupsTableUpdateValidator()
    {
        RuleForEach(
                entity =>
                    entity.Items
            )
            .Must(
                entity =>
                    entity.Id > 0
            )
            .WithMessage(
                "Id must be greater than 0."
            );
    }
}