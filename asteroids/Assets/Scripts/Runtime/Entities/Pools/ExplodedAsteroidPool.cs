using UnityEngine;

public class ExplodedAsteroidPool : EnemyPool
{
    public override void StartEnemy(Enemy explodedAsteroid)
    {
        var range = EnemyRangeConfig.Range;
        int itemsAmount = Random.Range(range.Min, range.Max);
        var point = explodedAsteroid.transform.position;

        for (int i = 0; i < itemsAmount; i++)
        {
            var position = RandomUtility.GetRandomPositionAroundPoint(point, 0f);
            var direction = RandomUtility.GetRandomDirection();
            var speed = Random.Range(SpeedRange.Min, SpeedRange.Max);

            var asteroid = GetFromPool();
            IMovement movement = new RigidbodyMovement(asteroid.Rigidbody, speed, position);
            asteroid.gameObject.SetActive(true);

            movement.SetMovingState(MovingState.Thrusting);
            movement.Move(direction);
        }

        WaveState.EnemiesCount += itemsAmount;
    }
}
