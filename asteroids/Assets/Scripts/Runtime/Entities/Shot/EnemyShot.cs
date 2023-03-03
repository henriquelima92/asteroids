using UnityEngine;
using UnityEngine.Events;

public class EnemyShot : Entity
{
    public ITimer Timer { get; private set; }
    private UnityAction<EnemyShot> _onDestroy;


    protected override void Update()
    {
        base.Update();
        Timer.UpdateCooldown();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var collisionLayer = collision.gameObject.layer;

        if (collisionLayer == LayerMask.NameToLayer(EntityUtility.Asteroid) || collisionLayer == LayerMask.NameToLayer(EntityUtility.PlayerShip))
        {
            _onDestroy?.Invoke(this);
        }
    }

    public void Initialize(float timeToDestroy, UnityAction<EnemyShot> onDestroy)
    {
        Timer = new Timer(timeToDestroy, () => { onDestroy?.Invoke(this); });
        _onDestroy = onDestroy;
    }
}
