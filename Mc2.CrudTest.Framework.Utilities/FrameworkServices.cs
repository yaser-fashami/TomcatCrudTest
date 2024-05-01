using Microsoft.Extensions.Logging;

namespace Mc2.CrudTest.Framework.Utilities;

public class FrameworkServices
{
    public readonly ILoggerFactory LoggerFactory;

    public FrameworkServices(ILoggerFactory loggerFactory)
    {
        LoggerFactory = loggerFactory;
    }
}