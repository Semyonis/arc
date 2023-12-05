using System.Collections.Generic;

using Arc.Infrastructure.Common.Interfaces;
using Arc.Infrastructure.Common.Models.Dependencies;
using Arc.Infrastructure.Repositories;

namespace Arc.Tests.Integrations.Factories.Dependencies;

public static class SolutionDependencyFactory
{
    public static IEnumerable<DependencyBase> GetDependencyItems() =>
        new IDependencyManager[]
            {
                new DependencyManager(),
                new Arc.Dependencies.Json.DependencyManager(),
                new Criteria.CompareFunctions.DependencyManager(),
                new Criteria.PropertyFilters.DependencyManager(),
                new Criteria.FilterParameters.Factories.DependencyManager(),
                new Criteria.FilterParameters.Factories.Generic.DependencyManager(),
                new Converters.DependencyManager(),
                new Converters.Base.DependencyManager(),
                new Converters.Views.Admins.DependencyManager(),
                new Converters.Views.Common.DependencyManager(),
                new Converters.Views.Users.DependencyManager(),
                new Facades.Admins.DependencyManager(),
                new Facades.Admins.Tables.DependencyManager(),
                new Facades.Anonymous.DependencyManager(),
                new Facades.Authorized.DependencyManager(),
                new Facades.Domain.DependencyManager(),
                new Facades.Domain.Filters.DependencyManager(),
                new Facades.Users.DependencyManager(),
                new Infrastructure.ConfigurationSettings.DependencyManager(),
                new Infrastructure.Exceptions.DependencyManager(),
                new Infrastructure.Repositories.Read.DependencyManager(),
                new Infrastructure.Services.DependencyManager(),
                new Infrastructure.Storages.DependencyManager(),
                new Infrastructure.Transactions.DependencyManager(),
            }
            .SelectMany(
                dependencyList =>
                    dependencyList.GetDependencies()
            );
}