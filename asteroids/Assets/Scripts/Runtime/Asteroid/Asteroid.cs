using UnityEngine;
using UnityEngine.Events;

public class Asteroid : Entity 
{
    private UnityAction<Asteroid> _onDestroy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var collisionLayer = collision.gameObject.layer;
        
        if(collisionLayer == LayerMask.NameToLayer(EntityUtility.PlayerShot) ||
            collisionLayer == LayerMask.NameToLayer(EntityUtility.PlayerShip))
        {
            _onDestroy.Invoke(this);
        }
    }

    public void SetOnDestroyAction(UnityAction<Asteroid> onDestroy)
    {
        _onDestroy = onDestroy;
    }

    public void Move(Vector3 position, Vector3 direction, float moveSpeed)
    {
        transform.position = position;
        gameObject.SetActive(true);

        IMovement movement = new Mover(_rigidbody, moveSpeed);
        movement.SetMovingState(MovingState.Thrusting);
        movement.Move(direction);
    }
}
