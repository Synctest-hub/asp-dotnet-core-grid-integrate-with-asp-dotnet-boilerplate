using Volo.Abp.Modularity;

namespace SyncfusionGrid;

[DependsOn(
    typeof(SyncfusionGridDomainModule),
    typeof(SyncfusionGridTestBaseModule)
)]
public class SyncfusionGridDomainTestModule : AbpModule
{

}
