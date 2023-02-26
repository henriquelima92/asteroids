using UnityEngine;
using UnityEngine.Events;

public class Asteroid : Entity
{
    private UnityAction<Transform> _onDestroy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var collisionObject = collision.gameObject;
        var collisionLayer = collisionObject.layer;
        

        if(collisionLayer == LayerMask.NameToLayer(EntityUtility.PlayerShot))
        {
            collisionObject.SetActive(false);
            gameObject.SetActive(false);
            
            _onDestroy.Invoke(transform);
        }
        else if(collisionLayer == LayerMask.NameToLayer(EntityUtility.PlayerShip))
        {
            gameObject.SetActive(false);

            _onDestroy.Invoke(transform);
        }
    }

    public void Initialize(UnityAction<Transform> onDestroy)
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
