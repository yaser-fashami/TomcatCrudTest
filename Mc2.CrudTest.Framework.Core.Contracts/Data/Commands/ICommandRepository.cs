using Mc2.CrudTest.Framework.Core.Domain.Entities;
using System.Linq.Expressions;

namespace Mc2.CrudTest.Framework.Core.Contracts.Data.Commands;

public interface ICommandRepository<TEntity> : IUnitOfWork
    where TEntity : AggregateRoot
{
    void Delete(ulong id);
    void Delete(TEntity entity);
    void Insert(TEntity entity);
    Task InsertAsync(TEntity entity);
    TEntity Get(ulong id);
    Task<TEntity> GetAsync(ulong id);
    bool Exists(Expression<Func<TEntity, bool>> expression);
    Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> expression);
}
