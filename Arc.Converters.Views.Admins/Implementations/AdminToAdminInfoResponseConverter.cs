using Arc.Converters.Views.Admins.Interfaces;
using Arc.Models.DataBase.Models;
using Arc.Models.Views.Admins.Models;

namespace Arc.Converters.Views.Admins.Implementations;

public sealed class AdminToAdminInfoResponseConverter :
    ConverterBase
    <
        Admin,
        AdminResponse
    >,
    IAdminToAdminInfoResponseConverter
{
    public override AdminResponse Convert(
        Admin entity
    ) =>
        new(
            entity.Id,
            entity.FirstName,
            entity.LastName,
            entity.Email
        );
}