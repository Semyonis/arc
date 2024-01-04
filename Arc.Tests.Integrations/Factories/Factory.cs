using Arc.Database.Context;
using Arc.Infrastructure.Exceptions.Implementations;
using Arc.Platform.Base.Factories;
using Arc.Platform.Base.Factories.Containers;
using Arc.Tests.Integrations.Factories.Dependencies;

using Microsoft.EntityFrameworkCore;

namespace Arc.Tests.Integrations.Factories;

internal sealed class Factory
{
    public Factory()
    {
        var baseDependencyItems =
            SolutionDependencyFactory.GetDependencyItems();

        var scopeInstanceDictionary =
            SubstituteDependencyFactory.GetInstancesDictionary();

        var dependencyContainer =
            new DependencyContainer(
                baseDependencyItems,
                scopeInstanceDictionary
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

        Context =
            DependencyFactory.GetImplementation<ArcDatabaseContext>();
    }

    public DbContext Context { get; }

    public DependencyFactory DependencyFactory { get; }
}