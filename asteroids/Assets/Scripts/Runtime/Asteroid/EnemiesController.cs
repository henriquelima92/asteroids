using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemiesController
{
    private MapBoundaries _mapBoundaries;
    private List<EnemyWave> _waves;
    private EnemiesData _enemies;

    private List<AsteroidPool> _pools;

    private int _wave;
    private int _enemiesCount;

    private UnityAction<Asteroid> GetNextLayerAsteroidAction(int nextLayerIndex)
    {
        void OnDestroyAsteroid(Asteroid asteroid)
        {
            _enemiesCount -= 1;

            var lastPoolIndex = _pools.Count - 1;
            if (nextLayerIndex <= lastPoolIndex)
            {
                _enemiesCount += _pools[nextLayerIndex].StartAsteroids(_waves[_wave], asteroid);
            }
            else
            {
                if(_enemiesCount <= 0)
                {
                    SetNextWave();
                    InitializeWave();
                }
            }
        }

        return OnDestroyAsteroid;
    }

    public void Initialize(EnemiesData enemiesData, WavesData wavesData, MapBoundariesData mapBoundariesData, GameController gameController)
    {
        _mapBoundaries = mapBoundariesData.MapBoundaries;
        _waves = wavesData.Waves;
        _enemies = enemiesData;

        _wave = 0;

        _pools = new List<AsteroidPool>();

        for (int i = 0; i < _enemies.Enemies.Count; i++)
        {
            var enemyData = _enemies.Enemies[i];

            var pool = Object.Instantiate(enemyData.Pool);
            pool.SetData(_mapBoundaries, enemyData.MoveSpeed, enemyData.EnemyType);
            _pools.Add(pool);
        }

        for (int i = 0; i < _pools.Count; i++)
        {
            _pools[i].Initialize(GetNextLayerAsteroidAction(i + 1));
        }

        InitializeWave();
    }

    public void ResetEnemies()
    {
        _enemiesCount = 0;
        _wave = 0;

        foreach (var pool in _pools)
        {
            pool.ReturnAllItemsToPool();
        }

        InitializeWave();
    }

    private void InitializeWave()
    {
        _enemiesCount += _pools[0].StartAsteroids(_waves[_wave]);
    }

    private void SetNextWave()
    {
        _wave = Mathf.Clamp(_wave + 1, 0, _waves.Count - 1);
    }
}
