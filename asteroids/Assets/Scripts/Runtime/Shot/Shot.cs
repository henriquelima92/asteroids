using UnityEngine;

public class Shot : Entity
{
    private ITimer _timer;

    protected override void Update()
    {
        base.Update();
        _timer.UpdateCooldown();
    }

    public void Initialize(float timeToDestroy)
    {
        _timer = new Timer(timeToDestroy, OnTimerEnd);
    }

    public void Move(Vector3 position, Vector3 direction, float moveSpeed)
    {
        _timer.ResetTimer();

        transform.position = position;
        gameObject.SetActive(true);

        IMovement movement = new Mover(_rigidbody, moveSpeed);
        movement.SetMovingState(MovingState.Thrusting);
        movement.Move(direction, ForceMode2D.Impulse);
    }

    private void OnTimerEnd()
    {
        gameObject.SetActive(false);
    }
}
