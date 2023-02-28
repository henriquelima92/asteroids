using UnityEngine;
using UnityEngine.Events;

public class Shot : Entity
{
    public IHighscore Highscore { get; private set; }
    public ITimer Timer { get; private set; }

    private UnityAction<Shot> _onDestroy;
    

    protected override void Update()
    {
        base.Update();
        Timer.UpdateCooldown();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var collisionLayer = collision.gameObject.layer;

        if(collisionLayer == LayerMask.NameToLayer(EntityUtility.Asteroid))
        {
            _onDestroy?.Invoke(this);
        }
    }

    public void Initialize(float timeToDestroy, UnityAction<Shot> onDestroy, IHighscore highscore)
    {
        Highscore = highscore;
        Timer = new Timer(timeToDestroy, () => { onDestroy?.Invoke(this); });

        _onDestroy = onDestroy;
    }
}
