using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController
{
    private GameController _gameController;
    private List<EnemyType> _enemiesFlow;
    private Dictionary<EnemyType, EnemyPool> _enemyPools;
    private List<EnemyWaveConfig> _waves;
    private IWaveState _waveState;

    public WaveController(WavesData waveData, Dictionary<EnemyType, EnemyPool> enemyPools, GameController gameController, float waveStartDelay)
    {
        _enemiesFlow = waveData.EnemiesFlow;
        _waves = waveData.Waves;

        _enemyPools = enemyPools;
        _gameController = gameController;

        _waveState = new WaveState(waveStartDelay, waveData.Waves.Count - 1, waveData.EnemiesFlow.Count - 1);

        for (int i = 0; i < _enemiesFlow.Count; i++)
        {
            var index = i;
            _enemyPools[_enemiesFlow[index]].Initialize(_waveState, (enemy) => OnDestroyEnemy(enemy, index + 1));
        }
    }

    public void InitializeWave()
    {
        _gameController.StartCoroutine(StartWave());
    }


    public void Reset()
    {
        _waveState.Reset();
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
        yield return new WaitForSeconds(_waveState.StartDelay);

        SetWaveConfigInPools(_waves[_waveState.CurrentWave]);

        StartFlowEnemies();
        StartRandomAppearanceEnemies();
    }

    private void StartFlowEnemies()
    {
        _enemyPools[_enemiesFlow[0]].StartEnemy();
    }

    private void StartRandomAppearanceEnemies()
    {
        foreach (var enemies in _waves[_waveState.CurrentWave].RandomAppearanceEnemies)
        {
            _enemyPools[enemies.EnemyType].Initialize(_waveState);
            _enemyPools[enemies.EnemyType].StartEnemy();
        }   
    }

    private void StopRandomAppearanceEnemies()
    {
        foreach (var enemies in _waves[_waveState.CurrentWave].RandomAppearanceEnemies)
        {
            _enemyPools[enemies.EnemyType].StopEnemy();
        }
    }

    private void OnDestroyEnemy(Enemy enemy, int nextLayerIndex)
    {
        _waveState.EnemiesCount -= 1;

        var lastPoolIndex = _waveState.EnemyLayers;
        if (nextLayerIndex <= lastPoolIndex)
        {
            _enemyPools[_enemiesFlow[nextLayerIndex]].StartEnemy(enemy);
            return;
        }

        if (_waveState.EnemiesCount <= 0)
        {
            StopRandomAppearanceEnemies();

            _waveState.GoToNextWave();
            InitializeWave();
        }
    }
}
