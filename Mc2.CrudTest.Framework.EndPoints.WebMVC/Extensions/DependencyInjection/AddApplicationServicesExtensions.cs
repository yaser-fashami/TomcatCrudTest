using Mc2.CrudTest.Framework.Core.ApplicationServices.Commands;
using Mc2.CrudTest.Framework.Core.Contracts.ApplicationServices.Commands;
using System.Reflection;

namespace Mc2.CrudTest.Framework.EndPoints.WebMVC.Extensions.DependencyInjection;

public static class AddApplicationServicesExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services,
                                                             IEnumerable<Assembly> assembliesForSearch)
    => services.AddCommandHandlers(assembliesForSearch)
               .AddCommandDispatcherDecorators();
               //.AddQueryHandlers(assembliesForSearch)
               //.AddQueryDispatcherDecorators()
               //.AddEventHandlers(assembliesForSearch)
               //.AddEventDispatcherDecorators()
               //.AddFluentValidators(assembliesForSearch);

    private static IServiceCollection AddCommandHandlers(this IServiceCollection services, IEnumerable<Assembly> assembliesForSearch)
    => services.AddWithTransientLifetime(assembliesForSearch, typeof(ICommandHandler<>), typeof(ICommandHandler<,>));

    private static IServiceCollection AddCommandDispatcherDecorators(this IServiceCollection services)
    {
        services.AddTransient<CommandDispatcher, CommandDispatcher>();
        services.AddTransient<CommandDispatcherDecorator, CommandDispatcherDomainExceptionHandlerDecorator>();
        services.AddTransient<CommandDispatcherDecorator, CommandDispatcherValidationDecorator>();

        services.AddTransient<ICommandDispatcher>(c =>
        {
            var commandDispatcher = c.GetRequiredService<CommandDispatcher>();
            var decorators = c.GetServices<CommandDispatcherDecorator>().ToList();
            if (decorators?.Any() == true)
            {
                decorators = decorators.OrderBy(c => c.Order).ToList();
                var listFinalIndex = decorators.Count - 1;
                for (int i = 0; i <= listFinalIndex; i++)
                {
                    if (i == listFinalIndex)
                    {
                        decorators[i].SetCommandDispatcher(commandDispatcher);

                    }
                    else
                    {
                        decorators[i].SetCommandDispatcher(decorators[i + 1]);
                    }
                }
                return decorators[0];
            }
            return commandDispatcher;
        });
        return services;
    }

}
