using System.Threading.Tasks;

namespace SyncfusionGrid.Data;

public interface ISyncfusionGridDbSchemaMigrator
{
    Task MigrateAsync();
}
