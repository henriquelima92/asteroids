using UnityEngine;

public static class RandomUtility
{
    public static Vector2 GetRandomDirection()
    {
        return new Vector2(Random.Range(0, 360), Random.Range(0, 360));
    }

    public static Vector2 GetRandomPositionAroundPoint(Vector2 point, float radius)
    {
        var randomPosition = Random.insideUnitCircle * radius;
        return point + randomPosition;
    }
}
