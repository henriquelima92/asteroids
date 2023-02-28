using UnityEngine;

public class ExplodedAsteroidPool : EnemyPool
{
    public override int StartEnemy(EnemyWaveConfig waveData, Enemy explodedAsteroid)
    {
        int itemsAmount = waveData.FindEnemyRandomRange(EnemyType);
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

        return itemsAmount;
    }
}
