using BepInEx;
using HarmonyLib;

namespace AmongUsFreezeTagMode
{
    [BepInPlugin("com.bugs257.freezetag", "Freeze Tag Mode", "1.0.0")]
    public class FreezeTagPlugin : BasePlugin
    {
        public static Harmony HarmonyInstance;

        public override void Load()
        {
            HarmonyInstance = new Harmony("com.bugs257.freezetag");
            HarmonyInstance.PatchAll();

            FreezeTagGameManager.Initialize();
        }
    }
}
