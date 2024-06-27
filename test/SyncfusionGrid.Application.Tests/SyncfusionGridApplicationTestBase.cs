using Volo.Abp.Modularity;

namespace SyncfusionGrid;

public abstract class SyncfusionGridApplicationTestBase<TStartupModule> : SyncfusionGridTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
