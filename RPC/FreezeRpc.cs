using Hazel;
using UnityEngine;

namespace AmongUsFreezeTagMode.RPC
{
    public static class FreezeRpc
    {
        public static void SendFreeze(byte playerId)
        {
            var writer = AmongUsClient.Instance.StartRpcImmediately(
                PlayerControl.LocalPlayer.NetId,
                70,
                SendOption.Reliable,
                -1
            );

            writer.Write(playerId);
            AmongUsClient.Instance.FinishRpcImmediately(writer);
        }

        public static void SendUnfreeze(byte playerId)
        {
            var writer = AmongUsClient.Instance.StartRpcImmediately(
                PlayerControl.LocalPlayer.NetId,
                71,
                SendOption.Reliable,
                -1
            );

            writer.Write(playerId);
            AmongUsClient.Instance.FinishRpcImmediately(writer);
        }
    }
}
