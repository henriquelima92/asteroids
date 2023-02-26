using System;
using UnityEngine;

[Serializable]
public class Life : ILife
{
    public int StartLives { get; private set; }

    [field: SerializeField] public int Lives { get; private set; }

    [field: SerializeField] public int MaxLives { get; private set; }

    public bool IsAlive => Lives > 0;

    public Life(int lives, int maxLives)
    {
        StartLives = lives;
        Lives = lives;
        MaxLives = maxLives;
    }

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

    public void Reset()
    {
        Lives = StartLives;
    }
}