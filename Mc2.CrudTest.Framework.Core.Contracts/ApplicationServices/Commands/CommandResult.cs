using Mc2.CrudTest.Framework.Core.Contracts.ApplicationServices.Common;

namespace Mc2.CrudTest.Framework.Core.Contracts.ApplicationServices.Commands;
public class CommandResult : ApplicationServiceResult
{
}

public class CommandResult<TData> : CommandResult
{
    public TData? _data;
    public TData? Data => _data;
}