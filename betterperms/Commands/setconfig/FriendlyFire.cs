using CommandSystem;
using System;

namespace BetterPerms.Commands.setconfig
{
    class FriendlyFire : ICommand
    {
        public string Command { get; } = "friendly_fire";

        public string[] Aliases { get; } = Array.Empty<string>();

        public string Description { get; } = "";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!new Methods().CheckSCPerms("friendlyfire", sender))
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
