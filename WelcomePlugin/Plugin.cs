using System;
using Nebuli.API.Features;
using Nebuli.Events.EventArguments.Player;
using Nebuli.Events.Handlers;

namespace WelcomePlugin

{
    public class Plugin : Plugin<Config>
    {
        public static Plugin Instance { get; set; }
        public override string Name => "WelcomeBroadcast";
        public override string Creator => "Heart";
        public override Version Version { get; } = new(1, 0, 0);
        public override Version NebuliVersion { get; } = new(1, 2, 2);

        public override void OnEnabled()
        {
            Instance = this;
            PlayerHandlers.Join += RunBroadcast;
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            PlayerHandlers.Join -= RunBroadcast;
            base.OnDisabled();
            Instance = null;
        }

        private void RunBroadcast(PlayerJoinEvent ev)
        { 
            Log.Debug($"Send Broadcast Message to {ev.Player.Nickname} ({ev.Player.UserId})");
            
            Config.BroadcastMessage = Config.BroadcastMessage.Replace("%player%", ev.Player.Nickname);
            ev.Player.Broadcast(Config.BroadcastMessage, Config.BroadcastDuration);
        }
    }
}