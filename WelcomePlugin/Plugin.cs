using System;
using System.Collections;
using System.Collections.Generic;
using MEC;
using Nebuli.API.Features;
using Nebuli.Events.EventArguments.Player;
using Nebuli.Events.EventArguments.Round;
using Nebuli.Events.Handlers;

namespace WelcomePlugin

{
    public class Plugin : Plugin<Config>
    {
        public static Plugin Instance { get; set; }
        public override string Name => "BroadcastManager";
        public override string Creator => "Heart";
        public override Version Version { get; } = new(1, 0, 0);
        public override Version NebuliVersion { get; } = new(1, 2, 3);

        public override void OnEnabled()
        {
            Instance = this;
            PlayerHandlers.Join += WelcomeBroadcast;
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            PlayerHandlers.Join -= WelcomeBroadcast;
            base.OnDisabled();
            Instance = null;
        }

        private void WelcomeBroadcast(PlayerJoinEvent ev)
        { 
            Log.Debug($"Send Welcome Broadcast Message to {ev.Player.Nickname} ({ev.Player.UserId})");
            if (Config.BroadcastsManager.TryGetValue("WelcomeBroadcast", out var welcomeBroadcastConfig))
            {
                if (welcomeBroadcastConfig.Show)
                {
                    var broadcastMessage = welcomeBroadcastConfig.Content.Replace("%player%", ev.Player.Nickname);
                    ev.Player.Broadcast(broadcastMessage, welcomeBroadcastConfig.Duration);
                }
            }
            else
            {
                Log.Error("Welcome broadcast configuration not found.");
            }
        }
    }
}