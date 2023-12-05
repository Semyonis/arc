using Arc.Converters.Views.Admins.Interfaces;
using Arc.Converters.Views.Common.Implementations;
using Arc.Database.Entities.Models;

namespace Arc.Converters.Views.Admins.Implementations;

public sealed class StringToGroupDescriptionConverter :
    StringToDescriptionEntityConverter<GroupDescription>,
    IStringToGroupDescriptionConverter;