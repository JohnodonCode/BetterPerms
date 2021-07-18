using CommandSystem;
using Exiled.API.Extensions;
using Exiled.API.Features;
using Exiled.Permissions.Extensions;
using RemoteAdmin;
using System;

namespace betterperms.Commands.setconfig
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    class SetConfigCommand : ParentCommand
    {
        public SetConfigCommand() => LoadGeneratedCommands();

        public override string Command { get; } = "setconfig";
        
        public override string[] Aliases { get; } = new string[] { };

        public override string Description { get; } = "Set server config values";

        public override void LoadGeneratedCommands()
        {
            RegisterCommand(new friendly_fire());
            RegisterCommand(new spawn_protect_disable());
            RegisterCommand(new spawn_protect_time());
            RegisterCommand(new player_list_title());
            RegisterCommand(new pd_refresh_exit());
            RegisterCommand(new human_grenade_multiplier());
            RegisterCommand(new scp_grenade_multiplier());
        }

        protected override bool ExecuteParent(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            response = "Invalid subcommand (0)";
            return false;
        }
    }
}
