public static class WinConditionSystem
{
    public static void CrewmateWin()
    {
        EndGame(GameOverReason.CrewmatesByTask);
    }

    public static void HunterWin()
    {
        EndGame(GameOverReason.ImpostorByKill);
    }

    private static void EndGame(GameOverReason reason)
    {
        AmongUsClient.Instance.RpcEndGame(reason, false);
    }
}
