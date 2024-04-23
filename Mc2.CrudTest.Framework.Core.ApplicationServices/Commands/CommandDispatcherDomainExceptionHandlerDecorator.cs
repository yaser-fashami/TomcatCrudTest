using Mc2.CrudTest.Framework.Core.Contracts.ApplicationServices.Commands;
using Mc2.CrudTest.Framework.Core.Contracts.ApplicationServices.Common;
using Mc2.CrudTest.Framework.Core.Domain.Exceptions;
using Mc2.CrudTest.Framework.Utilities.Services.Logger;
using Microsoft.Extensions.Logging;

namespace Mc2.CrudTest.Framework.Core.ApplicationServices.Commands;
public class CommandDispatcherDomainExceptionHandlerDecorator : CommandDispatcherDecorator
{
    #region Fields
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<CommandDispatcherDomainExceptionHandlerDecorator> _logger;
    #endregion

    #region Constructors
    public CommandDispatcherDomainExceptionHandlerDecorator(CommandDispatcher commandDispatcher, IServiceProvider serviceProvider , ILogger<CommandDispatcherDomainExceptionHandlerDecorator> logger) : base(commandDispatcher)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;
    }
    #endregion

    #region Send Commands
    public override async Task<CommandResult> Send<TCommand>(TCommand command)
    {
        try
        {
            var result = _commandDispatcher.Send(command);
            return await result;
        }
        catch (DomainStateException ex)
        {
            _logger.LogError(FrameworkEventId.DomainValidationException, ex, $"Processing of {command.GetType()} With value {command} failed at {DateTime.Now} because there are domain exceptions");
            return DomainExceptionHandlingWithoutReturnValue<TCommand>(ex);
        }
        catch(AggregateException ex)
        {
            if (ex.InnerException is DomainStateException domainStateException)
            {
                _logger.LogError(FrameworkEventId.DomainValidationException, domainStateException, $"Processing of {command.GetType()} With value {command} failed at {DateTime.Now} because there are domain exceptions");
                return DomainExceptionHandlingWithoutReturnValue<TCommand>(domainStateException);
            }
            throw ex;
        }        
    }

    public override async Task<CommandResult<TData>> Send<TCommand, TData>(TCommand command)
    {
        try
        {
            var result = await _commandDispatcher.Send<TCommand, TData>(command);
            return result;
        }
        catch (DomainStateException ex)
        {
            _logger.LogError(FrameworkEventId.DomainValidationException, ex, $"Processing of {command.GetType()} With value {command} failed at {DateTime.Now} because there are domain exceptions");
            return DomainExceptionHandlingWithReturnValue<TCommand, TData>(ex);
        }
        catch (AggregateException ex)
        {
            if (ex.InnerException is DomainStateException domainStateException)
            {
                _logger.LogError(FrameworkEventId.DomainValidationException, domainStateException, $"Processing of {command.GetType()} With value {command} failed at {DateTime.Now} because there are domain exceptions");
                return DomainExceptionHandlingWithReturnValue<TCommand, TData>(domainStateException);
            }
            throw ex;
        }

    }
    #endregion

    #region Private Methods
    private CommandResult DomainExceptionHandlingWithoutReturnValue<TCommand>(DomainStateException ex)
    {
        var commandResult = new CommandResult()
        {
            Status = ApplicationServiceStatus.InvalidDomainState
        };

        commandResult.AddMessage(ex.Message);
        return commandResult;
    }
    private CommandResult<TData> DomainExceptionHandlingWithReturnValue<TCommand, TData>(DomainStateException ex)
    {
        var commandResult = new CommandResult<TData>()
        {
            Status = ApplicationServiceStatus.InvalidDomainState
        };

        commandResult.AddMessage(ex.Message);
        return commandResult;
    }
    #endregion
}
