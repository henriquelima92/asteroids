using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemiesController
{
    private GameController _gameController;
    private MapBoundaries _mapBoundaries;
    private List<EnemyWaveConfig> _waves;

    private List<EnemyPool> _pools;

    private int _wave;
    private int _enemiesCount;
    private float _waveStartDelay;

   
    public void Initialize(EnemiesData enemiesData, WavesData wavesData, MapBoundariesData mapBoundariesData, GameController gameController)
    {
        _gameController = gameController;
        _mapBoundaries = mapBoundariesData.MapBoundaries;
        _waves = wavesData.Waves;
        _waveStartDelay = enemiesData.WaveStartDelay;

        var enemies = enemiesData.Enemies;

        _wave = 0;

        _pools = new List<EnemyPool>();

        for (int i = 0; i < enemies.Count; i++)
        {
            var enemyData = enemies[i];

            var pool = Object.Instantiate(enemyData.Pool);
            pool.SetData(_mapBoundaries, enemyData.MoveSpeed, enemyData.EnemyType, enemyData.Score);
            _pools.Add(pool);
        }

        for (int i = 0; i < _pools.Count; i++)
        {
            _pools[i].Initialize(GetNextLayerAsteroidAction(i + 1));
        }

        _gameController.StartCoroutine(InitializeWave());
    }

    public void ResetEnemies()
    {
        _enemiesCount = 0;
        _wave = 0;

        foreach (var pool in _pools)
        {
            pool.ResetPool();
        }

        _pools.Clear();
    }

    private UnityAction<Enemy> GetNextLayerAsteroidAction(int nextLayerIndex)
    {
        void OnDestroyAsteroid(Enemy asteroid)
        {
            _enemiesCount -= 1;

            var lastPoolIndex = _pools.Count - 1;
            if (nextLayerIndex <= lastPoolIndex)
            {
                _enemiesCount += _pools[nextLayerIndex].StartEnemy(_waves[_wave], asteroid);
            }
            else
            {
                if (_enemiesCount <= 0)
                {
                    SetNextWave();
                    _gameController.StartCoroutine(InitializeWave());
                }
            }
        }

        return OnDestroyAsteroid;
    }

    private IEnumerator InitializeWave()
    {
        yield return new WaitForSeconds(_waveStartDelay);
        _enemiesCount += _pools[0].StartEnemy(_waves[_wave]);
    }

    private void SetNextWave()
    {
        _wave = Mathf.Clamp(_wave + 1, 0, _waves.Count - 1);
    }
}
