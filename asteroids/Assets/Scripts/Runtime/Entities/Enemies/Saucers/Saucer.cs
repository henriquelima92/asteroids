using System.Collections.Generic;
using UnityEngine;

public class Saucer : Enemy
{
    public List<PlayerShip> _players;

    public void SetPlayers(List<PlayerShip> players)
    {
        _players = players;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var collisionLayer = collision.gameObject.layer;

        if (collisionLayer == LayerMask.NameToLayer(EntityUtility.PlayerShip))
        {
            var playerShip = collision.GetComponent<PlayerShip>();
            playerShip.Highscore.IncrementHighscore(Score);

            OnDestroy.Invoke(this);
        }
        else if (collisionLayer == LayerMask.NameToLayer(EntityUtility.PlayerShot))
        {
            var shot = collision.GetComponent<Shot>();
            shot.Highscore.IncrementHighscore(Score);

            OnDestroy.Invoke(this);
        }
        else if(collisionLayer == LayerMask.NameToLayer(EntityUtility.Asteroid))
        {
            var saucer = collision.GetComponent<Saucer>();
            foreach (var player in _players)
            {
                if(player.Life.IsAlive)
                {
                    player.Highscore.IncrementHighscore(Score);
                }
            }

            OnDestroy.Invoke(this);
        }
    }
}
