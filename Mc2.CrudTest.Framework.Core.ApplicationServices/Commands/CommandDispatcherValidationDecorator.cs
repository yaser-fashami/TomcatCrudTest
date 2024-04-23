using FluentValidation;
using Mc2.CrudTest.Framework.Core.Contracts.ApplicationServices.Commands;
using Mc2.CrudTest.Framework.Core.Contracts.ApplicationServices.Common;
using Mc2.CrudTest.Framework.Utilities.Services.Logger;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Mc2.CrudTest.Framework.Core.ApplicationServices.Commands;
public class CommandDispatcherValidationDecorator : CommandDispatcherDecorator
{
    #region Fields
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<CommandDispatcherValidationDecorator> _logger;
    #endregion

    #region Constructors
    public CommandDispatcherValidationDecorator(CommandDispatcherDomainExceptionHandlerDecorator commandDispatcher,
                                                IServiceProvider serviceProvider,
                                                ILogger<CommandDispatcherValidationDecorator> logger)
                                                : base(commandDispatcher)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;
    }
    #endregion

    #region Send Commands
    public override async Task<CommandResult> Send<TCommand>(TCommand command)
    {
        _logger.LogDebug(FrameworkEventId.CommandValidation, $"Validating command of type {command.GetType()} With value {command} start at :{DateTime.Now}");
        var validationResult = Validate<TCommand, CommandResult>(command);

        if (validationResult != null)
        {
            _logger.LogInformation(FrameworkEventId.CommandValidation, $"Validating command of type {command.GetType()} With value {command} failed, Validation errors are: {validationResult.Messages}");
            return validationResult;
        }
        _logger.LogDebug(FrameworkEventId.CommandValidation, $"Validating command of type {command.GetType()} With value {command} finished at :{DateTime.Now}");
        return await _commandDispatcher.Send(command);
    }

    public override async Task<CommandResult<TData>> Send<TCommand, TData>(TCommand command)
    {
        _logger.LogDebug(FrameworkEventId.CommandValidation, $"Validating command of type {command.GetType()} With value {command} start at :{DateTime.Now}");
        var validationResult = Validate<TCommand, CommandResult<TData>>(command);

        if (validationResult != null)
        {
            _logger.LogInformation(FrameworkEventId.CommandValidation, $"Validating command of type {command.GetType()} With value {command} failed, Validation errors are: {validationResult.Messages}");
            return validationResult;
        }
        _logger.LogDebug(FrameworkEventId.CommandValidation, $"Validating command of type {command.GetType()} With value {command} finished at :{DateTime.Now}");
        return await _commandDispatcher.Send<TCommand, TData>(command);
    }
    #endregion

    #region Private Methods
    private TValidationResult Validate<TCommand, TValidationResult>(TCommand command) where TValidationResult : ApplicationServiceResult, new()
    {
        var validator = _serviceProvider.GetService<IValidator<TCommand>>();
        TValidationResult res = null;

        if (validator != null)
        {
            var validationResult = validator.Validate(command);
            if (!validationResult.IsValid)
            {
                res = new()
                {
                    Status = ApplicationServiceStatus.ValidationError
                };
                foreach (var item in validationResult.Errors)
                {
                    res.AddMessage(item.ErrorMessage);
                }
            }
        }
        else
        {
            _logger.LogInformation(FrameworkEventId.CommandValidation, $"There is not any validator for {command.GetType()}");
        }
        return res;
    }
    #endregion
}
