using Arc.Infrastructure.Common.Enums;

namespace Arc.Infrastructure.Common.Interfaces;

public interface IWithOrderingType
{
    OrderingType OrderingType { get; }
}