using Arc.Converters.Views.Users.Interfaces;
using Arc.Models.DataBase.Models;
using Arc.Models.Views.Users.Models;

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