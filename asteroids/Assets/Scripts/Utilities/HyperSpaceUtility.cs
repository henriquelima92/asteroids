using UnityEngine;

public static class HyperSpaceUtility
{
    public static bool IsInHyperSpace(Vector3 position, MapBoundaries mapBoundaries)
    {
        return position.x < mapBoundaries.Left || position.x > mapBoundaries.Right ||
            position.y > mapBoundaries.Top || position.y < mapBoundaries.Bottom;
    }
}
