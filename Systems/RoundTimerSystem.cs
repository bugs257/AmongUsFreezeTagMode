using System.Collections;
using UnityEngine;
using MiraAPI.Utilities;

namespace AmongUsFreezeTagMode.Systems
{
    public static class RoundTimerSystem
    {
        public static float RoundDuration = 120f;
        public static float TimeLeft;

        public static void StartTimer()
        {
            TimeLeft = RoundDuration;
            CoroutineRunner.Start(TimerLoop());
        }

        private static IEnumerator TimerLoop()
        {
            while (TimeLeft > 0)
            {
                yield return new WaitForSeconds(1f);
                TimeLeft--;
                UpdateHUD();
            }

            WinConditionSystem.RunnersWin();
        }

        public static void ReduceTimeFromTask(float amount)
        {
            TimeLeft -= amount;

            if (TimeLeft < 0)
                TimeLeft = 0;

            UpdateHUD();
        }

        private static void UpdateHUD()
        {
            if (HudManager.Instance?.TaskPanel != null)
            {
                HudManager.Instance.TaskPanel.SetTaskText(
                    $"Freeze Tag\nTime Left: {Mathf.Ceil(TimeLeft)}s"
                );
            }
        }
    }
}
