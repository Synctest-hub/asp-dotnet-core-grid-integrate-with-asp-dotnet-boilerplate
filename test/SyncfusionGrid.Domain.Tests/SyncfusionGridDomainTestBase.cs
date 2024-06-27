using Volo.Abp.Modularity;

namespace SyncfusionGrid;

/* Inherit from this class for your domain layer tests. */
public abstract class SyncfusionGridDomainTestBase<TStartupModule> : SyncfusionGridTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
