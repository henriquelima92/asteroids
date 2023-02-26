using UnityEngine;
using UnityEngine.Events;

public abstract class AsteroidPool : GenericObjectPool<Asteroid>
{
    protected MapBoundaries MapBoundaries;
    protected FloatRange SpeedRange;
    protected EnemyType AsteroidType;

    public void SetData(MapBoundaries mapBoundaries, FloatRange speedRange, EnemyType asteroidType)
    {
        MapBoundaries = mapBoundaries;
        SpeedRange = speedRange;
        AsteroidType = asteroidType;
    }

    public void Initialize(UnityAction<Asteroid> onDestroy)
    {
        void OnAsteroidDestroy(Asteroid asteroid)
        {
            ReturnToPool(asteroid);
            onDestroy?.Invoke(asteroid);
        }

        foreach (var item in PooledItems)
        {
            item.Set(MapBoundaries);
            item.SetOnDestroyAction(OnAsteroidDestroy);
        }
    }

    public abstract int StartAsteroids(EnemyWave waveData, Asteroid explodedAsteroid = null);
}
