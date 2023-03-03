using System.Collections.Generic;
using UnityEngine;

public class Saucer : Enemy
{
    public List<PlayerShip> _players;

    private SaucerMovement _movement;
    private IShot _shooter;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        var collisionLayer = collision.gameObject.layer;

        if (collisionLayer == LayerMask.NameToLayer(EntityUtility.PlayerShip))
        {
            var playerShip = collision.GetComponent<PlayerShip>();
            playerShip.Highscore.IncrementHighscore(Score);

            OnDestroy.Invoke(this);
            ResetEnemy();
        }
        else if (collisionLayer == LayerMask.NameToLayer(EntityUtility.PlayerShot))
        {
            var shot = collision.GetComponent<Shot>();
            shot.Highscore.IncrementHighscore(Score);

            OnDestroy.Invoke(this);
            ResetEnemy();
        }
        else if (collisionLayer == LayerMask.NameToLayer(EntityUtility.Asteroid))
        {
            var saucer = collision.GetComponent<Saucer>();
            foreach (var player in _players)
            {
                if (player.Life.IsAlive)
                {
                    player.Highscore.IncrementHighscore(Score);
                }
            }

            ResetEnemy();
            OnDestroy.Invoke(this);
        }
    }

    protected override void Update()
    {
        base.Update();

        if (_movement.MovingState != MovingState.Thrusting)
        {
            return;
        }

        _movement.UpdateMovement();
        _shooter.Update();
    }

    public void InitializeSaucer(List<PlayerShip> players, IMovement movement, IShot shooter)
    {
        _players = players;
        _movement = movement as SaucerMovement;
        _shooter = shooter;
    }

    public override void ResetEnemy()
    {
        _movement.Reset();
        _shooter.Reset();
    }
}
