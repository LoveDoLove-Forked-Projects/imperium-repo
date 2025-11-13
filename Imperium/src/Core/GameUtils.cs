#region

using Photon.Pun;
using UnityEngine;

#endregion

namespace Imperium.Core;

public static class GameUtils
{
    internal static void PlayClip(AudioClip audioClip, bool randomize = false)
    {
        if (!Imperium.Settings.Preferences.PlaySounds.Value) return;
        // RoundManager.PlayRandomClip(Imperium.HUDManager.UIAudio, [audioClip], randomize);
    }
    
    public static GameObject? SpawnNetworkPrefab(
        PrefabRef prefab,
        Vector3 position,
        Quaternion rotation,
        byte group = 0,
        object[]? data = null)
    {
        if (!prefab.IsValid())
        {
            Imperium.IO.LogError("Failed to spawn network prefab. PrefabId is null.");
            return null;
        }
        if (!SemiFunc.IsMasterClientOrSingleplayer())
        {
            Imperium.IO.LogError($"Failed to spawn network prefab \"{prefab.PrefabName}\". You are not the host.");
            return null;
        }
        return SemiFunc.IsMultiplayer() ? PhotonNetwork.InstantiateRoomObject(prefab.ResourcePath, position, rotation, group, data) : Object.Instantiate(prefab.Prefab, position, rotation);
    }
}