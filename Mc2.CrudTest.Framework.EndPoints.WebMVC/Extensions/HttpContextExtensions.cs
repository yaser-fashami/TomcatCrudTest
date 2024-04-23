using Mc2.CrudTest.Framework.Core.Contracts.ApplicationServices.Commands;
using Mc2.CrudTest.Framework.Core.Contracts.ApplicationServices.Events;
using Mc2.CrudTest.Framework.Core.Contracts.ApplicationServices.Queries;

namespace Mc2.CrudTest.Framework.EndPoints.WebMVC.Extensions;

public static class HttpContextExtensions
{
    public static ICommandDispatcher CommandDispatcher(this HttpContext httpContext) =>
        httpContext.RequestServices.GetService(typeof(ICommandDispatcher)) as ICommandDispatcher;

    public static IQueryDispatcher QueryDispatcher(this HttpContext httpContext) =>
        httpContext.RequestServices.GetService(typeof(IQueryDispatcher)) as IQueryDispatcher;

    public static IEventDispatcher EventDispatcher(this HttpContext httpContext) =>
        httpContext.RequestServices.GetService(typeof(IEventDispatcher)) as IEventDispatcher;
}
