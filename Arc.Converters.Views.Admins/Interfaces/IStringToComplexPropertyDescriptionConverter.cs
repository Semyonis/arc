using Arc.Converters.Views.Common.Interfaces;
using Arc.Database.Entities.Models;

namespace Arc.Converters.Views.Admins.Interfaces;

public interface IStringToComplexPropertyDescriptionConverter :
    IStringToDescriptionEntityConverter<ComplexPropertyDescription>;