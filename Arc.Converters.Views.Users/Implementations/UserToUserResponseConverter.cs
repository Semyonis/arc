using Arc.Converters.Views.Users.Interfaces;
using Arc.Database.Entities.Models;
using Arc.Models.Views.Common.Models;

namespace Arc.Converters.Views.Users.Implementations;

public sealed class UserToUserResponseConverter :
    ConverterBase
    <
        User,
        UserResponse
    >,
    IUserToUserResponseConverter
{
    public override UserResponse Convert(
        User entity
    ) =>
        new(
            entity.Id,
            entity.FirstName,
            entity.LastName,
            entity.Email
        );
}