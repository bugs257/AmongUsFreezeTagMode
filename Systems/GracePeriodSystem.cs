using System.Collections;
using UnityEngine;
using MiraAPI.Utilities;

namespace AmongUsFreezeTagMode.Systems
{
    public static class GracePeriodSystem
    {
        public static float Duration = 12f;

        public static void StartGracePeriod()
        {
            var hunter = FreezeTagGameManager.Hunter;

            if (hunter != null)
                hunter.moveable = false;

            CoroutineRunner.Start(GraceTimer());
        }

        private static IEnumerator GraceTimer()
        {
            yield return new WaitForSeconds(Duration);

            if (FreezeTagGameManager.Hunter != null)
                FreezeTagGameManager.Hunter.moveable = true;

            RoundTimerSystem.StartTimer();
        }
    }
}
