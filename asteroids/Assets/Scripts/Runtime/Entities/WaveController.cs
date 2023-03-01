using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController
{
    private GameController _gameController;
    private List<EnemyType> _enemiesFlow;
    private Dictionary<EnemyType, EnemyPool> _enemyPools;
    private float _waveStartDelay;

    private List<EnemyWaveConfig> _waves;
    private int _enemiesCount;
    private int _currentWave;

    public WaveController(WavesData waveData, Dictionary<EnemyType, EnemyPool> enemyPools, GameController gameController, float waveStartDelay)
    {
        _enemiesFlow = waveData.EnemiesFlow;
        _waves = waveData.Waves;

        _enemyPools = enemyPools;
        _gameController = gameController;
        _waveStartDelay = waveStartDelay;

        for (int i = 0; i < _enemiesFlow.Count; i++)
        {
            var index = i;
            _enemyPools[_enemiesFlow[index]].Initialize((enemy) => OnDestroyEnemy(enemy, index + 1));
        }
    }

    public void InitializeWave()
    {
        _gameController.StartCoroutine(StartWave());
    }

    public void GoToNextWave()
    {
        _currentWave = Mathf.Clamp(_currentWave + 1, 0, _waves.Count - 1);
    }
    public void Reset()
    {
        _currentWave = 0;
        _enemiesCount = 0;
    }

    private void SetWaveConfigInPools(EnemyWaveConfig waveConfig)
    {
        foreach (var (enemyType, pool) in _enemyPools)
        {
            pool.SetWaveConfig(waveConfig);
        }
    }

    private IEnumerator StartWave()
    {
        yield return new WaitForSeconds(_waveStartDelay);

        SetWaveConfigInPools(_waves[_currentWave]);
        _enemiesCount = _enemyPools[_enemiesFlow[0]].StartEnemy();
    }


    private void OnDestroyEnemy(Enemy enemy, int nextLayerIndex)
    {
        _enemiesCount -= 1;

        var lastPoolIndex = _enemiesFlow.Count - 1;
        if (nextLayerIndex <= lastPoolIndex)
        {
            _enemiesCount += _enemyPools[_enemiesFlow[nextLayerIndex]].StartEnemy(enemy);
            return;
        }

        if (_enemiesCount <= 0)
        {
            GoToNextWave();
            InitializeWave();
        }
    }
}
