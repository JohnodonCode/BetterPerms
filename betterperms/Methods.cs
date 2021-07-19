using CommandSystem;
using Exiled.Permissions.Extensions;
using System;
using GameCore;

namespace betterperms
{
    class Methods
    {
        //command permissions
        internal bool CheckSCPerms(string node, ICommandSender sender)
        {
            if(!sender.CheckPermission($"ServerConfigs.{node}") && !sender.CheckPermission("ServerConfigs") && !sender.CheckPermission(PlayerPermissions.ServerConfigs))
            {
                return false;
            }
            return true;
        }
    }
}
