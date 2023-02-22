using System;
using System.Collections.Generic;
using UnityEngine;

public enum AsteroidType
{
    Big = 0,
    Medium = 1,
    Small = 2
}

[Serializable]
public class AsteroidsController
{
    [SerializeField] private MapBoundariesData _mapBoundariesData;
    [SerializeField] private HordeData _currentHorde;
    [SerializeField] private List<ObjectPool> _pools;

    public List<GameObject> Initialize()
    {
        var pools = new List<GameObject>();

        foreach (var asteroidPool in _pools)
        {
            var pool = asteroidPool.Initialize();
            pools.AddRange(pool);
        }

        SetHorde(_pools[0], _currentHorde.Horde.BigAsteroidsRange);

        return pools;
    }

    private void SetHorde(ObjectPool pool, Range range)
    {
        for (int i = 0; i < range.GetRandomRange(); i++)
        {
            var asteroid = pool.GetObjectFromPool<Asteroid>();
            InitializeAsteroid(asteroid, Vector2.zero, 10f);
        }
    }

    private void OnBigAsteroidDestroyed()
    {

    }

    private void OnMediumAsteroidDestroyed()
    {

    }

    private void OnSmallAsteroidDestroyed()
    {

    }

    private void InitializeAsteroid(Asteroid asteroid, Vector2 startPosition, float randomPositionRadius)
    {
        var position = RandomUtility.RandomPointInBox(_mapBoundariesData.MapBoundaries);
        var direction = RandomUtility.GetRandomDirection();

        asteroid.Initialize(position, direction, OnBigAsteroidDestroyed);
    }
}
