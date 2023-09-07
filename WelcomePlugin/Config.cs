using Nebuli.API.Interfaces;
using System.ComponentModel;

namespace WelcomePlugin
{
    public class Config : IConfiguration
    {
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = false;
        [Description("Message Configuration")]
        public string BroadcastMessage { get; set; } = "<color=#6EDAFF><size=55>Welcome <b>%player%!</b></size> \n<i>Make sure to read our rules! \nJoin our discord if you enjoy the server!</i></color>";
        public ushort BroadcastDuration { get; set; } = 6;
    }
}