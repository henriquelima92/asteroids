using UnityEngine;

public static class EntityUtility
{
    private static string PlayerShot = "PlayerShot";

    public static bool IsPlayerShot(GameObject entity)
    {
        return entity.layer == LayerMask.NameToLayer(PlayerShot);
    }
}
