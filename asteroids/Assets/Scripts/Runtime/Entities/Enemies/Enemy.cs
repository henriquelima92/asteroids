using UnityEngine.Events;

public abstract class Enemy : Entity
{
    protected int Score;
    protected UnityAction<Enemy> OnDestroy;

    public void Initialize(int score, UnityAction<Enemy> onDestroy)
    {
        Score = score;
        OnDestroy = onDestroy;
    }

    public virtual void Stop() { }
}