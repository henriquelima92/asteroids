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

    public static Vector2 RandomPointInBox(MapBoundaries mapBoundaries)
    {
        Vector2 pos;
        do
        {
            var randomX = (Random.value - 0.5f) * mapBoundaries.Size.x;
            var randomY = (Random.value - 0.5f) * mapBoundaries.Size.y;

            pos = mapBoundaries.Center + new Vector2(randomX, randomY);
        }
        while (IsInsideSafeArea(pos, mapBoundaries.Size, mapBoundaries.SafeAreaCenter, mapBoundaries.SafeAreaSize));

        return pos;
    }

    public static bool CanDo(float probability)
    {
        System.Random random = new System.Random();
        return random.NextDouble() < (probability / 100);
    }

    private static bool IsInsideSafeArea(Vector2 objectPosition, Vector2 objectSize, Vector2 safeAreaPosition, Vector2 safeAreaSize)
    {
        Rect safeAreaRect = new Rect(safeAreaPosition, safeAreaSize);
        Rect objectRect = new Rect(objectPosition, objectSize);

        return objectRect.Overlaps(safeAreaRect);
    }
}
