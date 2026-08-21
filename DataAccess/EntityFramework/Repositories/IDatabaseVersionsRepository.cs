using Eadent.Common.DataAccess.EntityFramework.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Eadent.Common.DataAccess.EntityFramework.Repositories
{
    public interface IDatabaseVersionsRepository : IBaseRepository<DatabaseVersionEntity, int>
    {
        Task<DatabaseVersionEntity> GetLatestOrDefaultAsync(CancellationToken cancellationToken = default);
    }
}
