using UnityEngine;

public class Shot : Entity
{
    protected override void Update()
    {
        base.Update();
    }

    public void Move(Vector3 position, Vector3 direction, float moveSpeed)
    {
        transform.position = position;
        gameObject.SetActive(true);

        IMovement movement = new Mover(_rigidbody, moveSpeed);
        movement.SetMovingState(MovingState.Thrusting);
        movement.Move(direction, ForceMode2D.Impulse);
    }
}
