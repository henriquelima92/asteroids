using UnityEngine;

public class BigAsteroidPool : AsteroidPool
{
    public override int StartAsteroids(EnemyWave waveData, Asteroid explodedAsteroid)
    {
        var itemsAmount = waveData.FindEnemyRandomRange(AsteroidType);
        for (int i = 0; i < itemsAmount; i++)
        {
            var position = RandomUtility.RandomPointInBox(MapBoundaries);
            var direction = RandomUtility.GetRandomDirection();
            var speed = Random.Range(SpeedRange.Min, SpeedRange.Max);

            var asteroid = GetFromPool();
            asteroid.Move(position, direction, speed);
        }

        return itemsAmount;
    }
}
