namespace Mc2.CrudTest.Framework.Core.Contracts.ApplicationServices.Queries;
public interface IQueryDispatcher
{
    Task<QueryResult<TData>> Execute<TQuery, TData>(TQuery query) where TQuery : class, IQuery<TData>;
}
