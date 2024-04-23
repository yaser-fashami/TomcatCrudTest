using Mc2.CrudTest.Framework.Core.Contracts.ApplicationServices.Commands;
using Mc2.CrudTest.Framework.Utilities.Services.Logger;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Data;
using System.Diagnostics;

namespace Mc2.CrudTest.Framework.Core.ApplicationServices.Commands;
public class CommandDispatcher : ICommandDispatcher
{
    #region Fields
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<CommandDispatcher> _logger;
    private readonly Stopwatch _stopWatch;
    #endregion

    #region Constructors
    public CommandDispatcher(IServiceProvider serviceProvider, ILogger<CommandDispatcher> logger)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;
        _stopWatch = new Stopwatch();
    }
    #endregion

    #region Send Commands
    public async Task<CommandResult> Send<TCommand>(TCommand command) where TCommand : class, ICommand
    {
        _stopWatch.Start();
        try
        {
            _logger.LogDebug($"Routing command of type {command.GetType()} With value {command} Start at {DateTime.Now}");
            var handler = _serviceProvider.GetRequiredService<ICommandHandler<TCommand>>();
            return await handler.Handle(command);
        }
        catch (InvalidOperationException ex)
        {
            _logger.LogError(ex, $"There is not suitable handler for {command.GetType()} Routing failed at {DateTime.Now}");
            throw;
        }
        finally
        {
            _stopWatch.Stop();
            _logger.LogInformation(FrameworkEventId.PerformanceMeasurment, $"Processing the {command.GetType()} command tooks {_stopWatch.ElapsedMilliseconds} milliseconds");
        }
    }

    public async Task<CommandResult<TData>> Send<TCommand, TData>(TCommand command) where TCommand : class, ICommand<TData>
    {
        _stopWatch.Start();
        try
        {
            _logger.LogDebug($"Routing command of type {command.GetType()} With value {command} Start at {DateTime.Now}");
            var handler = _serviceProvider.GetRequiredService<ICommandHandler<TCommand, TData>>();
            return await handler.Handle(command);
        }
        catch (InvalidOperationException ex)
        {
            _logger.LogError(ex, $"There is not suitable handler for {command.GetType()} Routing failed at {DateTime.Now}");
            throw;
        }
        finally
        {
            _stopWatch.Stop();
            _logger.LogInformation(FrameworkEventId.PerformanceMeasurment, $"Processing the {command.GetType()} command tooks {_stopWatch.ElapsedMilliseconds} milliseconds");
        }
    }
    #endregion

}
