using System.Linq;
using UnityEngine;

namespace AmongUsFreezeTagMode
{
    public static class FreezeTagGameManager
    {
        public static PlayerControl Hunter;

        public static void Initialize()
        {
            MiraAPI.Events.MiraEvents.OnGameStart += OnGameStart;
        }

        private static void OnGameStart()
        {
            AssignRoles();
            Systems.GracePeriodSystem.StartGracePeriod();
        }

        private static void AssignRoles()
        {
            var players = PlayerControl.AllPlayerControls.ToList();
            Hunter = players[Random.Range(0, players.Count)];

            foreach (var player in players)
            {
                if (player == Hunter)
                    player.AddRole(new Roles.HunterRole());
                else
                    player.AddRole(new Roles.RunnerRole());
            }
        }

        public static bool AllRunnersFrozen()
        {
            return PlayerControl.AllPlayerControls
                .Where(p => p != Hunter)
                .All(p => Systems.FreezeSystem.IsFrozen(p));
        }
    }
}
