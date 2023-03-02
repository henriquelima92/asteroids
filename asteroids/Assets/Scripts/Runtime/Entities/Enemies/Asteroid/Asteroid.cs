using UnityEngine;

public class Asteroid : Enemy 
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var collisionLayer = collision.gameObject.layer;

        if (collisionLayer == LayerMask.NameToLayer(EntityUtility.PlayerShip))
        {
            var playerShip = collision.GetComponent<PlayerShip>();
            playerShip.Highscore.IncrementHighscore(Score);

            OnDestroy.Invoke(this);
        }
        else if(collisionLayer == LayerMask.NameToLayer(EntityUtility.PlayerShot))
        {
            var shot = collision.GetComponent<Shot>();
            shot.Highscore.IncrementHighscore(Score);

            OnDestroy.Invoke(this);
        }
        else if(collisionLayer == LayerMask.NameToLayer(EntityUtility.Saucer))
        {
            OnDestroy.Invoke(this);
        }
    }
}
