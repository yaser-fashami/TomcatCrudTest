using Mc2.CrudTest.Framework.Core.Contracts.Data.Commands;
using Mc2.CrudTest.Framework.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Mc2.CrudTest.Framework.Infra.Data.Sql.Commands;

public class BaseCommandRepository<TEntity, TDbContext> : ICommandRepository<TEntity>, IUnitOfWork
    where TEntity : AggregateRoot
    where TDbContext : BaseCommandDbContext
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

    void ICommandRepository<TEntity>.Delete(ulong id)
    {
        var entity = _dbContext.Set<TEntity>().Find(id);
        _dbContext.Set<TEntity>().Remove(entity);
    }

    void ICommandRepository<TEntity>.Delete(TEntity entity)
    {
        _dbContext.Set<TEntity>().Remove(entity);
    }

    bool ICommandRepository<TEntity>.Exists(Expression<Func<TEntity, bool>> expression)
    {
        return _dbContext.Set<TEntity>().Any(expression);
    }

    async Task<bool> ICommandRepository<TEntity>.ExistsAsync(Expression<Func<TEntity, bool>> expression)
    {
        return await _dbContext.Set<TEntity>().AnyAsync(expression);
    }

    TEntity ICommandRepository<TEntity>.Get(ulong id)
    {
        return _dbContext.Set<TEntity>().Find(id);
    }

    async Task<TEntity> ICommandRepository<TEntity>.GetAsync(ulong id)
    {
        return await _dbContext.Set<TEntity>().FindAsync(id);
    }

    void ICommandRepository<TEntity>.Insert(TEntity entity)
    {
        _dbContext.Set<TEntity>().Add(entity);
    }

    async Task ICommandRepository<TEntity>.InsertAsync(TEntity entity)
    {
        await _dbContext.Set<TEntity>().AddAsync(entity);
    }

    public void RollbackTransaction()
    {
        _dbContext.Rollback();
    }
}
