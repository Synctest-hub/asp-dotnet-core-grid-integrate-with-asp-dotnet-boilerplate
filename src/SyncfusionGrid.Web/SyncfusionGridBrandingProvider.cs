using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace SyncfusionGrid.Web;

[Dependency(ReplaceServices = true)]
public class SyncfusionGridBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "SyncfusionGrid";
}
