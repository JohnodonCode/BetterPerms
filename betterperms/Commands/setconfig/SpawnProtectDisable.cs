using CommandSystem;
using System;

namespace BetterPerms.Commands.setconfig
{
    class SpawnProtectDisable : ICommand
    {
        public string Command { get; } = "spawn_protect_disable";

        public string[] Aliases { get; } = Array.Empty<string>();

        public string Description { get; } = "";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (Methods.CheckSCPerms("spawnprotectdisable", sender))
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
