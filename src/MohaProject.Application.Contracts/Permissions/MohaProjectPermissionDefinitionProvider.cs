﻿using MohaProject.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace MohaProject.Permissions;

public class MohaProjectPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(MohaProjectPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(MohaProjectPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<MohaProjectResource>(name);
    }
}
