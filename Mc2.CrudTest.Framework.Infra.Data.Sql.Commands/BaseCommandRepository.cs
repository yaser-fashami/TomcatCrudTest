using Mc2.CrudTest.Framework.Core.Contracts.Data.Commands;
using Mc2.CrudTest.Framework.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Security.Cryptography;

namespace Mc2.CrudTest.Framework.Infra.Data.Sql.Commands;

public class BaseCommandRepository<TEntity, TDbContext, TId> : ICommandRepository<TEntity, TId>, IUnitOfWork
    where TEntity : AggregateRoot
    where TDbContext : BaseCommandDbContext
    where TId : struct,
          IComparable,
          IComparable<TId>,
          IConvertible,
          IEquatable<TId>,
          IFormattable
{
    protected readonly TDbContext _dbContext;
    public BaseCommandRepository(TDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void BeginTransaction()
    {
        _dbContext.BeginTransaction();
    }

    public int Commit()
    {
        return _dbContext.SaveChanges();
    }

    public Task<int> CommitAsync()
    {
        return _dbContext.SaveChangesAsync();
    }

    public void CommitTransaction()
    {
        _dbContext.Commit();
    }

    public void Delete(TId id)
    {
        var entity = _dbContext.Set<TEntity>().Find(id);
        _dbContext.Set<TEntity>().Remove(entity);
    }

    public void Delete(TEntity entity)
    {
        _dbContext.Set<TEntity>().Remove(entity);
    }

    public bool Exists(Expression<Func<TEntity, bool>> expression)
    {
        return _dbContext.Set<TEntity>().Any(expression);
    }

    public async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> expression)
    {
        return await _dbContext.Set<TEntity>().AnyAsync(expression);
    }

    public TEntity Get(TId id)
    {
        return _dbContext.Set<TEntity>().Find(id);
    }

    public async Task<TEntity> GetAsync(TId id)
    {
        return await _dbContext.Set<TEntity>().FindAsync(id);
    }

    public void Insert(TEntity entity)
    {
        _dbContext.Set<TEntity>().Add(entity);
    }

    public async Task InsertAsync(TEntity entity)
    {
        await _dbContext.Set<TEntity>().AddAsync(entity);
    }

    public void RollbackTransaction()
    {
        _dbContext.Rollback();
    }
}
