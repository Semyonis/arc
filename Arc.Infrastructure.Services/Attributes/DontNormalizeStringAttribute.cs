using System;

namespace Arc.Infrastructure.Services.Attributes;

[AttributeUsage(
    AttributeTargets.Property
    | AttributeTargets.Field
    | AttributeTargets.Parameter
)]
public sealed class DontNormalizeStringAttribute :
    Attribute;