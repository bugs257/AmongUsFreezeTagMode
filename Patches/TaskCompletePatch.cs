using HarmonyLib;

namespace AmongUsFreezeTagMode.Patches
{
    [HarmonyPatch(typeof(PlayerControl), nameof(PlayerControl.CompleteTask))]
    public static class TaskCompletePatch
    {
        static void Postfix(PlayerControl __instance, uint taskId)
        {
            if (!AmongUsClient.Instance.AmHost) return;
            if (__instance == FreezeTagGameManager.Hunter) return;

            Systems.RoundTimerSystem.ReduceTimeFromTask(
                Systems.TaskHookSystem.TimeReductionPerTask
            );
        }
    }
}
