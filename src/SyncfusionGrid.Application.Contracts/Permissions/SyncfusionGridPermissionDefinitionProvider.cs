using SyncfusionGrid.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace SyncfusionGrid.Permissions;

public class SyncfusionGridPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(SyncfusionGridPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(SyncfusionGridPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<SyncfusionGridResource>(name);
    }
}
