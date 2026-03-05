using System.Collections.Generic;
using Hazel;
using UnityEngine;

namespace AmongUsFreezeTagMode.Systems
{
    public static class FreezeSystem
    {
        private static HashSet<byte> FrozenPlayers = new();

        public static bool IsFrozen(PlayerControl player)
            => FrozenPlayers.Contains(player.PlayerId);

        public static void Freeze(PlayerControl player)
        {
            if (player == null || IsFrozen(player)) return;

            FrozenPlayers.Add(player.PlayerId);
            player.moveable = false;

            RPC.FreezeRpc.SendFreeze(player.PlayerId);

            if (FreezeTagGameManager.AllRunnersFrozen())
                WinConditionSystem.HunterWin();
        }

        public static void Unfreeze(PlayerControl player)
        {
            if (player == null || !IsFrozen(player)) return;

            FrozenPlayers.Remove(player.PlayerId);
            player.moveable = true;

            RPC.FreezeRpc.SendUnfreeze(player.PlayerId);
        }
    }
}
