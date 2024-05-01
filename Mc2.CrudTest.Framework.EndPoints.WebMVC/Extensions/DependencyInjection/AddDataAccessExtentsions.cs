using Mc2.CrudTest.Framework.Core.Contracts.Data.Commands;
using Mc2.CrudTest.Framework.Core.Contracts.Data.Queries;
using System.Reflection;

namespace Mc2.CrudTest.Framework.EndPoints.WebMVC.Extensions.DependencyInjection;

public static class AddDataAccessExtentsions
{
    public static IServiceCollection AddZaminDataAccess(
    this IServiceCollection services,
    IEnumerable<Assembly> assembliesForSearch) =>
    services.AddRepositories(assembliesForSearch).AddUnitOfWorks(assembliesForSearch);

    public static IServiceCollection AddRepositories(this IServiceCollection services,
        IEnumerable<Assembly> assembliesForSearch) =>
        services.AddWithTransientLifetime(assembliesForSearch, typeof(ICommandRepository<,>), typeof(IQueryRepository));

    public static IServiceCollection AddUnitOfWorks(this IServiceCollection services,
        IEnumerable<Assembly> assembliesForSearch) =>
        services.AddWithTransientLifetime(assembliesForSearch, typeof(IUnitOfWork));

}
