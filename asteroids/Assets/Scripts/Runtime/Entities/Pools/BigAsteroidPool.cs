using UnityEngine;

public class BigAsteroidPool : EnemyPool
{
    public override int StartEnemy(EnemyWaveConfig waveData, Enemy explodedAsteroid)
    {
        var itemsAmount = waveData.FindEnemyRandomRange(EnemyType);
        for (int i = 0; i < itemsAmount; i++)
        {
            var position = RandomUtility.RandomPointInBox(MapBoundaries);
            var direction = RandomUtility.GetRandomDirection();
            var speed = Random.Range(SpeedRange.Min, SpeedRange.Max);

            var asteroid = GetFromPool();
            IMovement movement = new RigidbodyMovement(asteroid.Rigidbody, speed, position);
            asteroid.gameObject.SetActive(true);

            movement.SetMovingState(MovingState.Thrusting);
            movement.Move(direction);
        }

        return itemsAmount;
    }
}
