﻿namespace Mc2.CrudTest.Framework.Core.Contracts.ApplicationServices.Queries;
public interface IQueryHandler<TQuery, TData>
    where TQuery : class, IQuery<TData>
{
    Task<QueryResult<TData>> Handle(TQuery request);
}