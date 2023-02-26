using UnityEngine;
using UnityEngine.Events;

public abstract class AsteroidPool : GenericObjectPool<Asteroid>
{
    protected MapBoundaries MapBoundaries;
    protected FloatRange SpeedRange;
    protected EnemyType AsteroidType;
    protected int Score;

    public void SetData(MapBoundaries mapBoundaries, FloatRange speedRange, EnemyType asteroidType, int score)
    {
        MapBoundaries = mapBoundaries;
        SpeedRange = speedRange;
        AsteroidType = asteroidType;
        Score = score;
    }

    public void Initialize(UnityAction<Asteroid> onDestroy, UnityAction<int> setScore)
    {
        void OnAsteroidDestroy(Asteroid asteroid)
        {
            ReturnToPool(asteroid);
            onDestroy?.Invoke(asteroid);
            setScore?.Invoke(Score);
        }

        foreach (var item in PooledItems)
        {
            item.Set(MapBoundaries);
            item.SetOnDestroyAction(OnAsteroidDestroy);
        }
    }

    public abstract int StartAsteroids(EnemyWave waveData, Asteroid explodedAsteroid = null);
}
