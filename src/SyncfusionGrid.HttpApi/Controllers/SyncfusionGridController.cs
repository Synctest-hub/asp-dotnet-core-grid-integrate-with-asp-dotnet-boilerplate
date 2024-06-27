using SyncfusionGrid.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace SyncfusionGrid.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class SyncfusionGridController : AbpControllerBase
{
    protected SyncfusionGridController()
    {
        LocalizationResource = typeof(SyncfusionGridResource);
    }
}
