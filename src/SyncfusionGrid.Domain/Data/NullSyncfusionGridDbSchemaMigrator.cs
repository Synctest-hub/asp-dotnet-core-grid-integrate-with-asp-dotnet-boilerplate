using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace SyncfusionGrid.Data;

/* This is used if database provider does't define
 * ISyncfusionGridDbSchemaMigrator implementation.
 */
public class NullSyncfusionGridDbSchemaMigrator : ISyncfusionGridDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
