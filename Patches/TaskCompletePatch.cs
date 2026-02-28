[HarmonyPatch(typeof(PlayerControl), nameof(PlayerControl.CompleteTask))]
class TaskCompletePatch
{
    static void Postfix(PlayerControl __instance, uint taskId)
    {
        if (!AmongUsClient.Instance.AmHost) return;
        if (__instance == FreezeTagGameManager.Hunter) return;

        RoundTimerSystem.ReduceTimeFromTask();
    }
}
