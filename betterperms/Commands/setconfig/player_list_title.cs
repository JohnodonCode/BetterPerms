using CommandSystem;
using Exiled.Permissions.Extensions;
using System;
using GameCore;

namespace betterperms.Commands.setconfig
{
    class player_list_title : ICommand
    {
        public string Command { get; } = "player_list_title";

        public string[] Aliases { get; } = { };

        public string Description { get; } = "";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!sender.CheckPermission("ServerConfigs.playerlisttitle") && !sender.CheckPermission("ServerConfigs") && !sender.CheckPermission(PlayerPermissions.ServerConfigs))
            {
                response = "You do not have permission to use this command.";
                return false;
            }

            if (arguments.Count < 1)
            {
                response = "Usage: setconfig player_list_title (string)";
                return false;
            }
            
            string newTitle = string.Join(" ", arguments);
            ConfigFile.ServerConfig.SetString("player_list_title", newTitle);
            PlayerList.singleton.RefreshTitle();
            
            response = $"Set ServerConfig [player_list_title] to \"{newTitle}\"\nChanges will be applied next round.";
            return true;

        }

    }
}
