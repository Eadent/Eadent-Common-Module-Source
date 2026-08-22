using Eadent.Common.DataAccess.EntityFramework.Databases;
using Eadent.Common.DataAccess.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Eadent.Common.DataAccess.EntityFramework.Repositories
{
    public class DatabaseVersionsRepository<TDatabase> : BaseRepository<TDatabase, DatabaseVersionEntity, int>, IDatabaseVersionsRepository
        where TDatabase : IBaseDatabase
    {
        public DatabaseVersionsRepository(TDatabase database) : base(database)
        {
        }

        public async Task<DatabaseVersionEntity> GetLatestOrDefaultAsync(CancellationToken cancellationToken = default)
        {
            return await Database.Context.Set<DatabaseVersionEntity>()
                .OrderByDescending(entity => entity.DatabaseVersionId)
                .FirstOrDefaultAsync(cancellationToken);
        }
    }
}
