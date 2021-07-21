using Exiled.API.Interfaces;
using System.ComponentModel;

namespace betterperms
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;

        [Description("Base permission node for Server Configs (default ServerConfigs)")]
        public string ScBasePermission { get; private set; } = "ServerConfigs";
    }
}