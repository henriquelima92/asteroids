using UnityEngine;
using UnityEngine.Events;

public class Asteroid : Entity 
{
    private int _score;
    private UnityAction<Asteroid> _onDestroy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var collisionLayer = collision.gameObject.layer;

        if (collisionLayer == LayerMask.NameToLayer(EntityUtility.PlayerShip))
        {
            var playerShip = collision.GetComponent<PlayerShip>();
            playerShip.Highscore.IncrementHighscore(_score);

            _onDestroy.Invoke(this);
        }
        else if(collisionLayer == LayerMask.NameToLayer(EntityUtility.PlayerShot))
        {
            var shot = collision.GetComponent<Shot>();
            shot.Highscore.IncrementHighscore(_score);

            _onDestroy.Invoke(this);
        }
    }

    public void SetOnDestroyAction(UnityAction<Asteroid> onDestroy, int score)
    {
        _score = score;
        _onDestroy = onDestroy;
    }

    public void Move(Vector3 position, Vector3 direction, float moveSpeed)
    {
        IMovement movement = new Mover(_rigidbody, moveSpeed, position);
        gameObject.SetActive(true);

        movement.SetMovingState(MovingState.Thrusting);
        movement.Move(direction);
    }
}
