using UnityEngine;

public class ExplodedAsteroidPool : AsteroidPool
{
    public override int StartAsteroids(EnemyWave waveData, Asteroid explodedAsteroid)
    {
        int itemsAmount = waveData.FindEnemyRandomRange(AsteroidType);
        var point = explodedAsteroid.transform.position;

        for (int i = 0; i < itemsAmount; i++)
        {
            var position = RandomUtility.GetRandomPositionAroundPoint(point, 0f);
            var direction = RandomUtility.GetRandomDirection();
            var speed = Random.Range(SpeedRange.Min, SpeedRange.Max);

            var asteroid = GetFromPool();
            asteroid.Move(position, direction, speed);
        }

        return itemsAmount;
    }
}
