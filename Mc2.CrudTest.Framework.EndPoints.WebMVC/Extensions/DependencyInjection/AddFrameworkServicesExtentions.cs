using Mc2.CrudTest.Framework.Utilities;

namespace Mc2.CrudTest.Framework.EndPoints.WebMVC.Extensions.DependencyInjection;

public static class AddFrameworkServicesExtentions
{
    public static IServiceCollection AddFrameworkUntilityServices(
    this IServiceCollection services)
    {
        services.AddTransient<FrameworkServices>();
        return services;
    }

}
