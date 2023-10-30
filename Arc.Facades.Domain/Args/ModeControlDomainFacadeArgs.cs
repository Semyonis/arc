using Arc.Infrastructure.Common.Enums;

namespace Arc.Facades.Domain.Args;

public sealed record ModeControlDomainFacadeArgs(
    ServiceModeType Mode,
    int AdminId
);