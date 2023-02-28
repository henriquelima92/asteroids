using UnityEngine;
using UnityEngine.Events;

public class Shot : Entity
{
    public IHighscore Highscore { get; private set; }
    private ITimer _timer;

    private UnityAction<Shot> _onDestroy;
    

    protected override void Update()
    {
        base.Update();
        _timer.UpdateCooldown();
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

        _onDestroy = onDestroy;
        _timer = new Timer(timeToDestroy, () => { _onDestroy?.Invoke(this); });
    }

    public void Move(Vector3 position, Vector3 direction, float speed)
    {
        _timer.ResetTimer();
        IMovement movement = new Mover(_rigidbody, speed, position);

        gameObject.SetActive(true);
        movement.SetMovingState(MovingState.Thrusting);
        movement.Move(direction, ForceMode2D.Impulse);
    }
}
