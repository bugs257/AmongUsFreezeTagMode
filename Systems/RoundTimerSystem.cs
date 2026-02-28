public static class RoundTimerSystem
{
    public static float RoundDuration = 120f;
    public static float RemainingTime;
    public static bool IsRunning;

    public static void StartTimer()
    {
        RemainingTime = RoundDuration;
        IsRunning = true;
        CoroutineRunner.Start(TimerRoutine());
    }

    private static IEnumerator TimerRoutine()
    {
        while (RemainingTime > 0 && IsRunning)
        {
            yield return new WaitForSeconds(1f);
            RemainingTime--;
            UpdateHud();
        }

        if (RemainingTime <= 0)
            WinConditionSystem.CrewmateWin();
    }

    public static void ReduceTimeFromTask()
    {
        RemainingTime -= 7f; // task penalty

        if (RemainingTime < 0)
            RemainingTime = 0;

        UpdateHud();
    }

    private static void UpdateHud()
    {
        HudManager.Instance.TaskPanel.SetTaskText(
            $"Freeze Tag\nTime Left: {Mathf.Ceil(RemainingTime)}s"
        );
    }
}
