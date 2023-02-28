using System;
using UnityEngine;

[Serializable]
public class Life : ILife
{
    public Action OnLifeAdded { get; set; }
    public Action OnLifeRemoved { get; set; }

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

    public void AddLife()
    {
        Lives = Mathf.Clamp(Lives + 1, 0, MaxLives);
        OnLifeAdded?.Invoke();
    }

    public void RemoveLife()
    {
        Lives = Mathf.Clamp(Lives - 1, 0, MaxLives);
        OnLifeRemoved?.Invoke();
    }

    public void Reset()
    {
        Lives = StartLives;
    }
}