using CommandSystem;
using Exiled.Permissions.Extensions;
using System;

namespace betterperms.Commands.setconfig
{
    class spawn_protect_time : ICommand
    {
        public string Command { get; } = "spawn_protect_time";

        public string[] Aliases { get; } = { };

        public string Description { get; } = "";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!sender.CheckPermission("ServerConfigs.spawnprotecttime") && !sender.CheckPermission("ServerConfigs") && !sender.CheckPermission(PlayerPermissions.ServerConfigs))
            {
                response = "You do not have permission to use this command.";
                return false;
            }

            if (arguments.Count < 1)
            {
                response = "Usage: setconfig spawn_protect_time (time)";
                return false;
            }
            double time = 0;
            if (double.TryParse(arguments.At(0), out time))
            {
                CharacterClassManager.SProtectedDuration = (float)time;
                response = $"Set ServerConfig [spawn_protect_time] to {arguments.At(0)}";
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
