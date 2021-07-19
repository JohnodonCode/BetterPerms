using CommandSystem;
using Exiled.Permissions.Extensions;
using System;

namespace betterperms.Commands.setconfig
{
    class SpawnProtectTime : ICommand
    {
        public string Command { get; } = "spawn_protect_time";

        public string[] Aliases { get; } = Array.Empty<string>();

        public string Description { get; } = "";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!new Methods().CheckSCPerms("spawnprotecttime", sender))
            {
                response = "You do not have permission to use this command.";
                return false;
            }

            if (arguments.Count < 1)
            {
                response = "Usage: setconfig spawn_protect_time (time)";
                return false;
            }
            float time = 0;
            if (float.TryParse(arguments.At(0), out time))
            {
                CharacterClassManager.SProtectedDuration = time;
                response = $"Set ServerConfig [spawn_protect_time] to {arguments.At(0)}";
                return true;
            }
            response = "Invalid argument (0)\nERR: IsNaN";
            return false;
        }
    }
}
