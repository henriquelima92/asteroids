using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] private Mover _movement;

    private void Start()
    {
        _movement.SetMovingState(MovingState.Thrusting);
        _movement.Move(RandomUtility.GetRandomDirection());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var collisionObject = collision.gameObject;
        var collisionLayer = collisionObject.layer;
        

        if(collisionLayer == LayerMask.NameToLayer(EntityUtility.PlayerShot))
        {
            collisionObject.SetActive(false);
            gameObject.SetActive(false);
        }
        else if(collisionLayer == LayerMask.NameToLayer(EntityUtility.PlayerShip))
        {
            collisionObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
