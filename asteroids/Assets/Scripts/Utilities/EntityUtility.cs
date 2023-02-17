﻿using UnityEngine;

public static class EntityUtility
{
    public static string PlayerShot = "PlayerShot";

    public static bool IsPlayerShot(GameObject entity)
    {
        return entity.layer == LayerMask.NameToLayer(PlayerShot);
    }
}
