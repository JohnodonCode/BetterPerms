using CommandSystem;
using Exiled.Permissions.Extensions;
using System;
using GameCore;

namespace betterperms.Commands.setconfig
{
    class spawn_protect_disable : ICommand
    {
        public string Command { get; } = "spawn_protect_disable";

        public string[] Aliases { get; } = { };

        public string Description { get; } = "";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!sender.CheckPermission("ServerConfigs.spawnprotectdisable") && !sender.CheckPermission("ServerConfigs") && !sender.CheckPermission("ServerConfigs.spawnprotect") && !sender.CheckPermission(PlayerPermissions.ServerConfigs))
            {
                response = "You do not have permission to use this command.";
                return false;
            }

            if (arguments.Count < 1)
            {
                response = "Usage: setconfig spawn_protect_disable (true/false)";
                return false;
            }

            switch (arguments.At(0).ToLower())
            {
                case "enable":
                case "true":
                    CharacterClassManager.EnableSP = false;
                    response = "Set ServerConfig [spawn_protect_disable] to True";
                    return true;
                case "false":
                case "disable":
                    CharacterClassManager.EnableSP = true;
                    response = "Set ServerConfig [spawn_protect_disable] to False";
                    return true;
                default:
                    response = "Invalid argument (0)";
                    return false;

            }
        }
    }
}
