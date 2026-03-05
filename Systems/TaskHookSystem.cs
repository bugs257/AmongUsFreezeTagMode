using AmongUsFreezeTagMode.Patches;

namespace AmongUsFreezeTagMode.Systems
{
    public static class TaskHookSystem
    {
        public static float TimeReductionPerTask = 7f;

        public static void EnableTaskHooks()
        {
            HarmonyPatches.ApplyPatches();
        }
    }
}
