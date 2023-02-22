using System;
using UnityEngine;
using UnityEngine.Events;

public class Asteroid : MonoBehaviour
{
    [SerializeField] private Mover _movement;

    private Observable _observable = new Observable();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var collisionObject = collision.gameObject;
        var collisionLayer = collisionObject.layer;
        

        if(collisionLayer == LayerMask.NameToLayer(EntityUtility.PlayerShot))
        {
            collisionObject.SetActive(false);
            gameObject.SetActive(false);
            
            _observable.Invoke();
        }
        else if(collisionLayer == LayerMask.NameToLayer(EntityUtility.PlayerShip))
        {
            collisionObject.SetActive(false);
            gameObject.SetActive(false);

            _observable.Invoke();
        }
    }

    public void Initialize(Vector2 position, Vector2 direction, UnityAction onDestroy)
    {
        transform.position = position;
        _observable.AddListener(onDestroy);

        gameObject.SetActive(true);

        _movement.SetMovingState(MovingState.Thrusting);
        _movement.Move(direction);
    }
}
