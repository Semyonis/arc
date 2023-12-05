using Arc.Converters.Base.Interfaces;
using Arc.Database.Entities.Models;
using Arc.Models.Views.Users.Models;

namespace Arc.Converters.Views.Users.Interfaces;

public interface IUserToUserResponseConverter :
    IConverterBase
    <
        User,
        UserResponse
    >;