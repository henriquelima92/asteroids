using System;
using UnityEngine;
using UnityEngine.Events;

public class Asteroid : MonoBehaviour
{
    [SerializeField] private Mover _movement;

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

    public void Initialize(Vector2 position, Vector2 direction, UnityAction<Transform> onDestroy)
    {
        transform.position = position;
        gameObject.SetActive(true);

        _observable.AddListener(onDestroy);
        _movement.SetMovingState(MovingState.Thrusting);
        _movement.Move(direction);
    }
}
