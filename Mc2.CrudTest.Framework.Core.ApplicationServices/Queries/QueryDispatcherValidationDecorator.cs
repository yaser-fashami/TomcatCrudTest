﻿using FluentValidation;
using Mc2.CrudTest.Framework.Core.Contracts.ApplicationServices.Common;
using Mc2.CrudTest.Framework.Core.Contracts.ApplicationServices.Queries;
using Mc2.CrudTest.Framework.Utilities.Services.Logger;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Mc2.CrudTest.Framework.Core.ApplicationServices.Queries;

public class QueryDispatcherValidationDecorator : QueryDispatcherDecorator
{
    #region Fields
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<QueryDispatcherValidationDecorator> _logger;
    public override int Order => 1;
    #endregion

    #region Constructors
    public QueryDispatcherValidationDecorator(IServiceProvider serviceProvider,
                                              ILogger<QueryDispatcherValidationDecorator> logger)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;
    }
    #endregion

    #region Query Dispatcher
    public override async Task<QueryResult<TData>> Execute<TQuery, TData>(TQuery query)
    {
        _logger.LogDebug(FrameworkEventId.QueryValidation, "Validating query of type {QueryType} With value {Query}  start at :{StartDateTime}", query.GetType(), query, DateTime.Now);

        var validationResult = Validate<TQuery, QueryResult<TData>>(query);

        if (validationResult != null)
        {
            _logger.LogInformation(FrameworkEventId.QueryValidation, "Validating query of type {QueryType} With value {Query}  failed. Validation errors are: {ValidationErrors}", query.GetType(), query, validationResult.Messages);
            return validationResult;
        }

        _logger.LogDebug(FrameworkEventId.QueryValidation, "Validating query of type {QueryType} With value {Query}  finished at :{EndDateTime}", query.GetType(), query, DateTime.Now);
        return await _queryDispatcher.Execute<TQuery, TData>(query);
    }
    #endregion

    #region Privaite Methods
    private TValidationResult Validate<TQuery, TValidationResult>(TQuery query) where TValidationResult : ApplicationServiceResult, new()
    {
        var validator = _serviceProvider.GetService<IValidator<TQuery>>();
        TValidationResult res = null;

        if (validator != null)
        {
            var validationResult = validator.Validate(query);
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
            _logger.LogInformation(FrameworkEventId.CommandValidation, "There is not any validator for {QueryType}", query.GetType());
        }
        return res;
    }
    #endregion
}