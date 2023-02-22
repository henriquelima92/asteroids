using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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
            InitializeAsteroid(asteroid, OnBigAsteroidDestroyed);
        }
    }

    private void OnBigAsteroidDestroyed(Transform obj)
    {
        var mediumAsteroidsPool = _pools[1];

        for (int i = 0; i < _currentHorde.Horde.MediumAsteroidsRange.GetRandomRange(); i++)
        {
           var asteroid = mediumAsteroidsPool.GetObjectFromPool<Asteroid>();
            InitializeAsteroid(asteroid, OnMediumAsteroidDestroyed);
        }
    }

    private void OnMediumAsteroidDestroyed(Transform obj)
    {
        var smallAsteroidsPool = _pools[2];

        for (int i = 0; i < _currentHorde.Horde.SmallAsteroidsRange.GetRandomRange(); i++)
        {
            var asteroid = smallAsteroidsPool.GetObjectFromPool<Asteroid>();
            InitializeAsteroid(asteroid, OnSmallAsteroidDestroyed);
        }
    }

    private void OnSmallAsteroidDestroyed(Transform obj)
    {

    }

    private void InitializeAsteroid(Asteroid asteroid, UnityAction<Transform> onDestroy)
    {
        var position = RandomUtility.RandomPointInBox(_mapBoundariesData.MapBoundaries);
        var direction = RandomUtility.GetRandomDirection();

        asteroid.Initialize(position, direction, onDestroy);
    }
}
