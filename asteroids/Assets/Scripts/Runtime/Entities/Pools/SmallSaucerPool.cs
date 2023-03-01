using UnityEngine;

public class SmallSaucerPool : EnemyPool
{
    private RandomAppearanceEnemyConfig _enemyConfig;

    public override void SetWaveConfig(EnemyWaveConfig waveConfig)
    {
        if(waveConfig.RandomAppearanceEnemies.Count < 1)
        {
            return;
        }

        _enemyConfig = waveConfig.FindRandomAppearanceEnemy(EnemyType);
    }
    public override int StartEnemy(Enemy enemy = null)
    {
        var direction = (Random.Range(0, 100) < 50) ? Vector2.right : Vector2.left;
        var speed = Random.Range(SpeedRange.Min, SpeedRange.Max);

        var yPosition = Random.Range(MapBoundaries.Top, MapBoundaries.Bottom);
        var xPosition = direction == Vector2.right ? MapBoundaries.Left : MapBoundaries.Right;
        var position = new Vector2(xPosition, yPosition);

        var saucer = GetFromPool();
        IMovement movement = new RigidbodyMovement(saucer.Rigidbody, speed, position);

        saucer.gameObject.SetActive(true);
        movement.SetMovingState(MovingState.Thrusting);
        movement.Move(direction);

        return 1;
    }
}
