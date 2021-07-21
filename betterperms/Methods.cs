﻿using CommandSystem;
using Exiled.Permissions.Extensions;

namespace betterperms
{
    class Methods
    {
        //command permissions
        internal bool CheckSCPerms(string node, ICommandSender sender)
        {
            if(!sender.CheckPermission($"{Plugin.Instance.Config.ScBasePermission}.{node}") && !sender.CheckPermission(Plugin.Instance.Config.ScBasePermission) && !sender.CheckPermission(PlayerPermissions.ServerConfigs))
            {
                return false;
            }
            return true;
        }
    }
}
