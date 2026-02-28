public sealed class RunnerRole : CrewmateRole
{
    public RunnerRole(IntPtr ptr) : base(ptr) { }

    public override string Name => "Runner";
    public override Color RoleColor => new(0f, 0.6f, 1f);
}
