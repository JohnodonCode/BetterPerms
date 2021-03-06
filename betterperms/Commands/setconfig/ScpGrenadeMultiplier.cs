using CommandSystem;
using GameCore;
using System;

namespace BetterPerms.Commands.setconfig
{
    class ScpGrenadeMultiplier : ICommand
    {
        public string Command { get; } = "scp_grenade_multiplier";

        public string[] Aliases { get; } = Array.Empty<string>();

        public string Description { get; } = "";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (Methods.CheckSCPerms("scpgrenademultiplier", sender))
            {
                response = "You do not have permission to use this command.";
                return false;
            }

            if (arguments.Count < 1)
            {
                response = "Usage: setconfig scp_grenade_multiplier (time)";
                return false;
            }
            double multiplier = 0;
            if (double.TryParse(arguments.At(0), out multiplier))
            {
                ConfigFile.ServerConfig.SetString("scp_grenade_multiplier", $"{multiplier * 100}");
                response = $"Set ServerConfig [scp_grenade_multiplier] to {multiplier * 100}";
                return true;
            }
            response = "Invalid argument (0)\nERR: IsNaN";
            return false;
        }
    }
}
