using UnityEngine;

namespace AmongUsFreezeTagMode.Systems
{
    public static class WinConditionSystem
    {
        public static void HunterWin()
        {
            AmongUsClient.Instance.RpcEndGame(
                GameOverReason.ImpostorByKill, false);
        }

        public static void RunnersWin()
        {
            AmongUsClient.Instance.RpcEndGame(
                GameOverReason.CrewmatesByTask, false);
        }
    }
}
