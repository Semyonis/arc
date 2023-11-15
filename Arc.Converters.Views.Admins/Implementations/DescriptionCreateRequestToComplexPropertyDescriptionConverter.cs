using Arc.Converters.Views.Admins.Interfaces;
using Arc.Converters.Views.Common.Implementations;
using Arc.Models.DataBase.Models;

namespace Arc.Converters.Views.Admins.Implementations;

public sealed class DescriptionCreateRequestToComplexPropertyDescriptionConverter :
    BaseDescriptionCreateRequestConverter<ComplexPropertyDescription>,
    IDescriptionCreateRequestToComplexPropertyDescriptionConverter;