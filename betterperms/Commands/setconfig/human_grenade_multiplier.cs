using CommandSystem;
using Exiled.Permissions.Extensions;
using System;
using GameCore;

namespace betterperms.Commands.setconfig
{
    class human_grenade_multiplier : ICommand
    {
        public string Command { get; } = "human_grenade_multiplier";

        public string[] Aliases { get; } = { };

        public string Description { get; } = "";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!sender.CheckPermission("ServerConfigs.humangrenademultiplier") && !sender.CheckPermission("ServerConfigs") && !sender.CheckPermission(PlayerPermissions.ServerConfigs))
            {
                response = "You do not have permission to use this command.";
                return false;
            }

            if (arguments.Count < 1)
            {
                response = "Usage: setconfig human_grenade_multiplier (time)";
                return false;
            }
            double multiplier = 0;
            if (double.TryParse(arguments.At(0), out multiplier))
            {
                ConfigFile.ServerConfig.SetString("human_grenade_multiplier", $"{multiplier * 100}");
                response = $"Set ServerConfig [human_grenade_multiplier] to {multiplier * 100}";
                return true;
            }
            else
            {
                response = "Invalid argument (0)\nERR: IsNaN";
                return false;
            }
        }
    }
}
