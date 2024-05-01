using Mc2.CrudTest.Framework.Core.Domain.Entities;
using System.Linq.Expressions;

namespace Mc2.CrudTest.Framework.Core.Contracts.Data.Commands;

public interface ICommandRepository<TEntity, TId> : IUnitOfWork
where TEntity : AggregateRoot
 where TId : struct,
      IComparable,
      IComparable<TId>,
      IConvertible,
      IEquatable<TId>,
      IFormattable
{
    void Delete(TId id);
    void Delete(TEntity entity);
    void Insert(TEntity entity);
    Task InsertAsync(TEntity entity);
    TEntity Get(TId id);
    Task<TEntity> GetAsync(TId id);
    bool Exists(Expression<Func<TEntity, bool>> expression);
    Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> expression);

}
