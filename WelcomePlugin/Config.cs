using Nebuli.API.Interfaces;
using System;
using System.Collections.Generic;

namespace WelcomePlugin
{
    public class BroadcastConfig
    {
        public string Content { get; set; } = "<color=#6EDAFF><size=55>Welcome <b>%player%!</b></size> \n<i>Make sure to read our rules! \nJoin our discord if you enjoy the server!</i></color>";
        public ushort Duration { get; set; } = 6;
        public bool Show { get; set; } = true;
    }

    public class Config : IConfiguration
    {
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = false;
        public Dictionary<string, BroadcastConfig> BroadcastsManager { get; set; } = new Dictionary<string, BroadcastConfig>
        {
            {
                "WelcomeBroadcast", new BroadcastConfig()
            }
        };
    }
}