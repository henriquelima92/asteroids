using System;
using UnityEngine;

[Serializable]
public struct MapBoundaries
{
    public Vector2 Center;
    public Vector2 Size;

    public Vector2 SafeAreaCenter;
    public Vector2 SafeAreaSize;

    public float Left => Center.x - Size.x / 2;
    public float Right => Center.x + Size.x / 2;
    public float Top => Center.y + Size.y / 2;
    public float Bottom => Center.y - Size.y / 2;
}
