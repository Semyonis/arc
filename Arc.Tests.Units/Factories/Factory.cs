using System;

using Arc.Infrastructure.Exceptions.Implementations;
using Arc.Platform.Base.Factories;
using Arc.Platform.Base.Factories.Containers;
using Arc.Tests.Units.Factories.Dependencies;

namespace Arc.Tests.Units.Factories;

internal sealed class Factory
{
    public Factory()
    {
        var typeDependencies =
            SolutionDependencyFactory.GetDependencyItems();

        // ReSharper disable once CollectionNeverUpdated.Local
        var instanceDependencies =
            new Dictionary<Type, object>();

        var dependencyContainer =
            new DependencyContainer(
                typeDependencies,
                instanceDependencies
            );

        var multipleConstructorsExceptionDescriptor =
            new MultipleConstructorsExceptionDescriptor();

        var badDataExceptionDescriptor =
            new BadDataExceptionDescriptor();

        DependencyFactory =
            new(
                dependencyContainer,
                multipleConstructorsExceptionDescriptor,
                badDataExceptionDescriptor
            );
    }

    public DependencyFactory DependencyFactory { get; }
}