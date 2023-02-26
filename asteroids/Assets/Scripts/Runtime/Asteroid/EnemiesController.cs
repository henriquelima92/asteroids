using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemiesController
{
    private MapBoundaries _mapBoundaries;
    private List<EnemyWave> _waves;
    private EnemiesData _enemies;

    private Dictionary<EnemyType, ObjectPool> _pools;

    private int _wave;
    private int _enemiesCount;

    public List<GameObject> Initialize(EnemiesData enemiesData, WavesData wavesData, MapBoundariesData mapBoundariesData)
    {
        _mapBoundaries = mapBoundariesData.MapBoundaries;
        _waves = wavesData.Waves;
        _enemies = enemiesData;

        _wave = 0;

        var enemies = new List<GameObject>();
        _pools = new Dictionary<EnemyType, ObjectPool>();

        foreach (var enemy in _enemies.Enemies)
        {
            var pool = new ObjectPool(enemy.EnemyPrefab, enemy.MaxAmount, enemy.EnemyType.ToString());
            var enemyObjects = pool.Initialize();

            _pools.Add(enemy.EnemyType, pool);
            enemies.AddRange(enemyObjects);
        }

        SetWave(_pools[EnemyType.BigAsteroid], _waves[_wave].FindEnemyRandomRange(EnemyType.BigAsteroid));

        return enemies;
    }

    private void SetWave(ObjectPool pool, int enemysAmount)
    {
        for (int i = 0; i < enemysAmount; i++)
        {
            var asteroid = pool.GetObjectFromPool<Asteroid>();
            InitializeAsteroid(asteroid, _enemies.FindEnemy(EnemyType.BigAsteroid).MoveSpeed, OnBigAsteroidDestroyed);
        }
    }

    private void OnBigAsteroidDestroyed(Transform obj)
    {
        _enemiesCount -= 1;

        var mediumAsteroidsPool = _pools[EnemyType.MediumAsteroid];

        for (int i = 0; i < _waves[0].FindEnemyRandomRange(EnemyType.MediumAsteroid); i++)
        {
            var asteroid = mediumAsteroidsPool.GetObjectFromPool<Asteroid>();
            InitializeExplodedAsteroid(asteroid, obj.position, _enemies.FindEnemy(EnemyType.MediumAsteroid).MoveSpeed, OnMediumAsteroidDestroyed);
        }
    }

    private void OnMediumAsteroidDestroyed(Transform obj)
    {
        _enemiesCount -= 1;

        var smallAsteroidsPool = _pools[EnemyType.SmallAsteroid];

        for (int i = 0; i < _waves[0].FindEnemyRandomRange(EnemyType.SmallAsteroid); i++)
        {
            var asteroid = smallAsteroidsPool.GetObjectFromPool<Asteroid>();
            InitializeExplodedAsteroid(asteroid, obj.position, _enemies.FindEnemy(EnemyType.SmallAsteroid).MoveSpeed, OnSmallAsteroidDestroyed);
        }
    }

    private void OnSmallAsteroidDestroyed(Transform obj)
    {
        _enemiesCount -= 1;

        if(_enemiesCount <= 0)
        {
            _wave = Mathf.Clamp(_wave + 1, 0, _waves.Count - 1);
            SetWave(_pools[EnemyType.BigAsteroid], _waves[_wave].FindEnemyRandomRange(EnemyType.BigAsteroid));
        }
    }

    private void InitializeExplodedAsteroid(Asteroid asteroid, Vector2 explosionPosition, float moveSpeed, UnityAction<Transform> onDestroy)
    {
        _enemiesCount += 1;

        var position = RandomUtility.GetRandomPositionAroundPoint(explosionPosition, 2f);
        var direction = RandomUtility.GetRandomDirection();

        asteroid.Set(_mapBoundaries);
        asteroid.Initialize(onDestroy);
        asteroid.Move(position, direction, moveSpeed);
    }

    private void InitializeAsteroid(Asteroid asteroid, float moveSpeed, UnityAction<Transform> onDestroy)
    {
        _enemiesCount += 1;

        var position = RandomUtility.RandomPointInBox(_mapBoundaries);
        var direction = RandomUtility.GetRandomDirection();

        asteroid.Set(_mapBoundaries);
        asteroid.Initialize(onDestroy);
        asteroid.Move(position, direction, moveSpeed);
    }
}
