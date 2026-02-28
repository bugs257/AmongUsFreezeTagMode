[BepInPlugin("com.bugs257.freezetag", "Freeze Tag Mode", "1.0.0")]
public class FreezeTagPlugin : BasePlugin
{
    public override void Load()
    {
        FreezeTagGameManager.Initialize();
    }
}
