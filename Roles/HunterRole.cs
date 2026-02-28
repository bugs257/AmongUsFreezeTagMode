public sealed class HunterRole : ImpostorRole
{
    public HunterRole(IntPtr ptr) : base(ptr) { }

    public override string Name => "Hunter";
    public override Color RoleColor => new(1f, 0f, 0f);
}
