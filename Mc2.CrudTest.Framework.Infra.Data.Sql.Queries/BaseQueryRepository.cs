using Mc2.CrudTest.Framework.Core.Contracts.Data.Queries;

namespace Mc2.CrudTest.Framework.Infra.Data.Sql.Queries;

public class BaseQueryRepository<TDbConetxt> : IQueryRepository
    where TDbConetxt : BaseQueryDbContext
{
    protected readonly TDbConetxt _dbContext;
    public BaseQueryRepository(TDbConetxt dbConetxt)
    {
        _dbContext = dbConetxt;
    }
}
