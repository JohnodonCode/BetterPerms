using CommandSystem;
using System;

namespace BetterPerms.Commands.setconfig
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    class SetConfigCommand : ParentCommand
    {
        public SetConfigCommand() => LoadGeneratedCommands();

        public override string Command { get; } = "setconfig";

        public override string[] Aliases { get; } = Array.Empty<string>();

        public override string Description { get; } = "Set server config values";

        public override void LoadGeneratedCommands()
        {
            RegisterCommand(new FriendlyFire());
            RegisterCommand(new SpawnProtectDisable());
            RegisterCommand(new SpawnProtectTime());
            RegisterCommand(new PlayerListTitle());
            RegisterCommand(new PDRefreshExit());
            RegisterCommand(new HumanGrenadeMultiplier());
            RegisterCommand(new ScpGrenadeMultiplier());
        }

        protected override bool ExecuteParent(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            response = "Invalid subcommand (0)";
            return false;
        }
    }
}
