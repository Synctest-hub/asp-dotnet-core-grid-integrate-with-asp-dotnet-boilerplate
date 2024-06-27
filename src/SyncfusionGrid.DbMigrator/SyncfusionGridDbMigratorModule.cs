using SyncfusionGrid.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace SyncfusionGrid.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(SyncfusionGridEntityFrameworkCoreModule),
    typeof(SyncfusionGridApplicationContractsModule)
    )]
public class SyncfusionGridDbMigratorModule : AbpModule
{
}
