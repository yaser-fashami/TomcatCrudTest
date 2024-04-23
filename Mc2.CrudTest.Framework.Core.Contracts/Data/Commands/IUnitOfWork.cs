namespace Mc2.CrudTest.Framework.Core.Contracts.Data.Commands;
public interface IUnitOfWork
{
    void BeginTransaction();
    void CommitTransaction();
    void RollbackTransaction();
    int Commit();
    Task<int> CommitAsync();
}
