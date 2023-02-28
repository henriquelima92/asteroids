using System;

public interface ILife
{
    public Action OnLifeAdded { get; set;  }
    public Action OnLifeRemoved { get; set; }

    public int StartLives { get; }
    public int Lives { get; }
    public int MaxLives { get; }
    public bool IsAlive { get; }

    public void RemoveLife();
    public void AddLife();

    public void Reset();
}