using Volo.Abp.Modularity;

namespace SyncfusionGrid;

[DependsOn(
    typeof(SyncfusionGridApplicationModule),
    typeof(SyncfusionGridDomainTestModule)
)]
public class SyncfusionGridApplicationTestModule : AbpModule
{

}
