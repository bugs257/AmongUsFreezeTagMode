public static class TaskDisableSystem
{
    public static void ModifyGameOptions()
    {
        var options = GameOptionsManager.Instance.currentNormalGameOptions;

        options.NumCommonTasks = 1;
        options.NumShortTasks = 3;
        options.NumLongTasks = 1;

        options.NumEmergencyMeetings = 0;
    }
}
