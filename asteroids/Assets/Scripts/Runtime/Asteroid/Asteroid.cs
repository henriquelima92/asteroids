using UnityEngine;
using UnityEngine.Events;

public class Asteroid : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    public Rigidbody2D Rigidbody2D => _rigidbody2D;

    private IMovement _movement;

    private OnDestroyObservable<Transform> _observable = new OnDestroyObservable<Transform>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var collisionObject = collision.gameObject;
        var collisionLayer = collisionObject.layer;
        

        if(collisionLayer == LayerMask.NameToLayer(EntityUtility.PlayerShot))
        {
            collisionObject.SetActive(false);
            gameObject.SetActive(false);
            
            _observable.Invoke(transform);
        }
        else if(collisionLayer == LayerMask.NameToLayer(EntityUtility.PlayerShip))
        {
            collisionObject.SetActive(false);
            gameObject.SetActive(false);

            _observable.Invoke(transform);
        }
    }

    public void Initialize(Vector3 direction, Vector3 position, float moveSpeed, UnityAction<Transform> onDestroy)
    {
        _observable.AddListener(onDestroy);
        transform.position = position;
        gameObject.SetActive(true);

        _movement = new Mover(_rigidbody2D, moveSpeed);
        _movement.SetMovingState(MovingState.Thrusting);
        _movement.Move(direction);
    }
}
