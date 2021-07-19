using CommandSystem;
using Exiled.Permissions.Extensions;
using System;
using GameCore;

namespace betterperms.Commands.setconfig
{
    class PDRefreshExit : ICommand
    {
        public string Command { get; } = "pd_refresh_exit";

        public string[] Aliases { get; } = Array.Empty<string>();

        public string Description { get; } = "";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!new Methods().CheckSCPerms("pdrefreshexit", sender))
            {
                response = "You do not have permission to use this command.";
                return false;
            }

            if (arguments.Count < 1)
            {
                response = "Usage: setconfig pd_refresh_exit (true/false)";
                return false;
            }

            switch (arguments.At(0).ToLower())
            {
                case "enable":
                case "true":
                    ConfigFile.ServerConfig.SetString("pd_refresh_exit", "true");
                    response = "Set ServerConfig [pd_refresh_exit] to True\nChanges will be applied next round.";
                    return true;
                case "false":
                case "disable":
                    ConfigFile.ServerConfig.SetString("pd_refresh_exit", "false");
                    response = "Set ServerConfig [pd_refresh_exit] to False\nChanges will be applied next round.";
                    return true;
                default:
                    response = "Invalid argument (0)";
                    return false;

            }
        }

    }
}
