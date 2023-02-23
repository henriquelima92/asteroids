using System;
using UnityEngine;

[Serializable]
public class Life : ILife
{
    [field: SerializeField] public int Lives { get; private set; }

    [field: SerializeField] public int MaxLives { get; private set; }

    public bool IsAlive => Lives > 0;

    public int AddLife()
    {
        Lives = Mathf.Clamp(Lives + 1, 0, MaxLives);
        return Lives;
    }

    public int RemoveLife()
    {
        Lives = Mathf.Clamp(Lives - 1, 0, MaxLives);
        return Lives;
    }

    public Life(int lives, int maxLives)
    {
        Lives = lives;
        MaxLives = maxLives;
    }
}