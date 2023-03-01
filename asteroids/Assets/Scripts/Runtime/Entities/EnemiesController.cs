using System.Collections.Generic;
using UnityEngine;

public class EnemiesController
{
    private WaveController _waveController;
  
    public void Initialize(EnemiesData enemiesData, WavesData wavesData, MapBoundariesData mapBoundariesData, GameController gameController)
    {
        var mapBoundaries = mapBoundariesData.MapBoundaries;
        var enemyConfigs = enemiesData.Enemies;
        var pools = new Dictionary<EnemyType, EnemyPool>();

        for (int i = 0; i < enemyConfigs.Count; i++)
        {
            var enemyData = enemyConfigs[i];

            var pool = Object.Instantiate(enemyData.Pool);
            pool.SetData(mapBoundaries, enemyData.MoveSpeed, enemyData.EnemyType, enemyData.Score);
            pools.Add(enemyData.EnemyType, pool);
        }

        _waveController = new WaveController(wavesData, pools, gameController, enemiesData.WaveStartDelay);
        _waveController.InitializeWave();
    }
    public void ResetEnemies()
    {
        _waveController.Reset();
    }
}
