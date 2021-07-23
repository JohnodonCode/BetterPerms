using Exiled.API.Features;
using System;

namespace BetterPerms
{
    public class Plugin : Plugin<Config>
    {
        public static Plugin Instance;

        // Metadata
        public override string Author { get; } = "Johnodon";
        public override string Name { get; } = "BetterPerms";
        public override string Prefix { get; } = "BetterPerms";
        public override Version Version { get; } = new Version(1, 1, 1);
        public override Version RequiredExiledVersion { get; } = new Version(2, 11, 1);

        public override void OnEnabled()
        {
            Instance = this;
            base.OnEnabled();
        }
        public override void OnDisabled()
        {
            Instance = null;
            base.OnDisabled();
        }
    }
}