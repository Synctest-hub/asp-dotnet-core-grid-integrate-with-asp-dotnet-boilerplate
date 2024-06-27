using System;
using System.Collections.Generic;
using System.Text;
using SyncfusionGrid.Localization;
using Volo.Abp.Application.Services;

namespace SyncfusionGrid;

/* Inherit your application services from this class.
 */
public abstract class SyncfusionGridAppService : ApplicationService
{
    protected SyncfusionGridAppService()
    {
        LocalizationResource = typeof(SyncfusionGridResource);
    }
}
