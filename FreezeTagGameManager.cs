public static class FreezeTagGameManager
{
    public static bool GracePeriodActive = true;
    public static PlayerControl Hunter;

    public static void Initialize()
    {
        MiraEvents.OnGameStart += OnGameStart;
    }

    private static void OnGameStart()
    {
        TaskDisableSystem.ModifyGameOptions();
        AssignRoles();
        GracePeriodSystem.StartGracePeriod();
    }

    private static void AssignRoles()
    {
        var players = PlayerControl.AllPlayerControls.ToList();
        Hunter = players[UnityEngine.Random.Range(0, players.Count)];

        foreach (var player in players)
        {
            if (player == Hunter)
                player.SetRole(new HunterRole(player.Pointer));
            else
                player.SetRole(new RunnerRole(player.Pointer));
        }
    }

    public static void CheckWinCondition()
    {
        var runners = PlayerControl.AllPlayerControls
            .Where(p => p != Hunter);

        if (runners.All(p => FreezeSystem.IsFrozen(p)))
        {
            WinConditionSystem.HunterWin();
        }
    }
}
