using Exiled.API.Features;
using System;
using ServerE = Exiled.Events.Handlers.Server;

namespace betterperms
{
    public class Plugin : Plugin<Config>
    {
        // Metadata
        public override string Author { get; } = "Johnodon";
        public override string Name { get; } = "BetterPerms";
        public override string Prefix { get; } = "BP";
        public override Version Version { get; } = new Version(1, 0, 1);
        public override Version RequiredExiledVersion { get; } = new Version(2, 11, 1);
    }
}