using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemiesController
{
    private MapBoundaries _mapBoundaries;
    private List<EnemyWave> _waves;
    private List<Enemy> _enemies;

    private List<ObjectPool> _pools;

    public List<GameObject> Initialize(EnemyData enemiesData, WavesData wavesData, MapBoundariesData mapBoundariesData)
    {
        _mapBoundaries = mapBoundariesData.MapBoundaries;
        _waves = wavesData.Waves;
        _enemies = enemiesData.Enemies;

        var enemies = new List<GameObject>();

        foreach (var enemy in _enemies)
        {
            var pool = new ObjectPool(enemy.EnemyPrefab, enemy.MaxAmount, enemy.EnemyType.ToString());
            var enemyObjects = pool.Initialize();

            enemies.AddRange(enemyObjects);
        }

        return enemies;

        //var pools = new List<GameObject>();

        //foreach (var asteroidPool in _pools)
        //{
        //    var pool = asteroidPool.Initialize();
        //    pools.AddRange(pool);
        //}

        //SetWave(_pools[0], _waves[0].FindEnemyRandomRange(EnemyType.BigAsteroid));

        //return pools;
    }

    private void SetWave(ObjectPool pool, int enemysAmount)
    {
        for (int i = 0; i < enemysAmount; i++)
        {
            var asteroid = pool.GetObjectFromPool<Asteroid>();
            InitializeAsteroid(asteroid, OnBigAsteroidDestroyed);
        }
    }

    private void OnBigAsteroidDestroyed(Transform obj)
    {
        var mediumAsteroidsPool = _pools[1];

        for (int i = 0; i < _waves[0].FindEnemyRandomRange(EnemyType.MediumAsteroid); i++)
        {
           var asteroid = mediumAsteroidsPool.GetObjectFromPool<Asteroid>();
            InitializeAsteroid(asteroid, OnMediumAsteroidDestroyed);
        }
    }

    private void OnMediumAsteroidDestroyed(Transform obj)
    {
        var smallAsteroidsPool = _pools[2];

        for (int i = 0; i < _waves[0].FindEnemyRandomRange(EnemyType.SmallAsteroid); i++)
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
        var position = RandomUtility.RandomPointInBox(_mapBoundaries);
        var direction = RandomUtility.GetRandomDirection();

        IMovement movement = new Mover(asteroid.Rigidbody2D, 10f);
        movement.Move(direction);
        movement.SetMovingState(MovingState.Thrusting);

        asteroid.Initialize(movement, position, onDestroy);
    }
}
