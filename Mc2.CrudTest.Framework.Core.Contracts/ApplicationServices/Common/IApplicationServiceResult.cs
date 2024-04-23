namespace Mc2.CrudTest.Framework.Core.Contracts.ApplicationServices.Common;
public interface IApplicationServiceResult
{
    IEnumerable<string> Messages { get; }
    ApplicationServiceStatus Status { get; set; }
}
