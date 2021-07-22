using CommandSystem;
using Exiled.Permissions.Extensions;

namespace BetterPerms
{
    class Methods
    {
        //command permissions
        internal static bool CheckSCPerms(string node, ICommandSender sender)
        {
            if(!sender.CheckPermission($"{Plugin.Instance.Config.ScBasePermission}.{node}") && !sender.CheckPermission(Plugin.Instance.Config.ScBasePermission) && !sender.CheckPermission(PlayerPermissions.ServerConfigs))
            {
                return false;
            }
            return true;
        }
    }
}
