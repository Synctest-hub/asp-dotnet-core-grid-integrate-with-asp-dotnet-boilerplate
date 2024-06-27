using SyncfusionGrid.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace SyncfusionGrid.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class SyncfusionGridPageModel : AbpPageModel
{
    protected SyncfusionGridPageModel()
    {
        LocalizationResourceType = typeof(SyncfusionGridResource);
    }
}
