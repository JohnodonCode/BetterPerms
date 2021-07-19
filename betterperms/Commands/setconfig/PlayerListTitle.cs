using CommandSystem;
using GameCore;
using System;

namespace betterperms.Commands.setconfig
{
    class PlayerListTitle : ICommand
    {
        public string Command { get; } = "player_list_title";

        public string[] Aliases { get; } = Array.Empty<string>();

        public string Description { get; } = "";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!new Methods().CheckSCPerms("playerlisttitle", sender))
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
