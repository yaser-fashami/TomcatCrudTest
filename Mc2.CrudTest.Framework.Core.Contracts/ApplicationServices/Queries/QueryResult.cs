using Mc2.CrudTest.Framework.Core.Contracts.ApplicationServices.Common;

namespace Mc2.CrudTest.Framework.Core.Contracts.ApplicationServices.Queries;
public class QueryResult<TData> : ApplicationServiceResult
{
    public TData? _data;
    public TData? Data { get => _data; }
}
