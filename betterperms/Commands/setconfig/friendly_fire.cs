using CommandSystem;
using Exiled.Permissions.Extensions;
using System;

namespace betterperms.Commands.setconfig
{
    class friendly_fire : ICommand
    {
        public string Command { get; } = "friendly_fire";

        public string[] Aliases { get; } = { };

        public string Description { get; } = "";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!sender.CheckPermission("ServerConfigs.friendlyfire") && !sender.CheckPermission("ServerConfigs") && !sender.CheckPermission(PlayerPermissions.ServerConfigs))
            {
                response = "You do not have permission to use this command.";
                return false;
            }

            if (arguments.Count < 1)
            {
                response = "Usage: setconfig friendly_fire (true/false)";
                return false;
            }

            switch (arguments.At(0).ToLower())
            {
                case "enable":
                case "true":
                    ServerConsole.FriendlyFire = true;
                    response = "Set ServerConfig [friendly_fire] to True";
                    return true;
                case "false":
                case "disable":
                    ServerConsole.FriendlyFire = false;
                    response = "Set ServerConfig [friendly_fire] to False";
                    return true;
                default:
                    response = "Invalid argument (0)";
                    return false;

            }
        }
    }
}
