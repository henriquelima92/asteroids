using UnityEngine;

public static class EntityUtility
{
    public static string PlayerShot = "PlayerShot";
    public static string PlayerShip = "PlayerShip";
    public static string Asteroid = "Asteroid";
    public static string Saucer = "Saucer";

    public static bool IsPlayerShot(GameObject entity)
    {
        return entity.layer == LayerMask.NameToLayer(PlayerShot);
    }
}
