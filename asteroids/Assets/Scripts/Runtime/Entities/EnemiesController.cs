using System.Collections.Generic;
using UnityEngine;

public class EnemiesController
{
    private WaveController _waveController;
  
    public void Initialize(EnemiesData enemiesData, WavesData wavesData, MapBoundariesData mapBoundariesData, GameController gameController, 
        List<PlayerShip> players)
    {
        var mapBoundaries = mapBoundariesData.MapBoundaries;
        var enemyConfigs = enemiesData.Enemies;
        var pools = new Dictionary<EnemyType, EnemyPool>();

        for (int i = 0; i < enemyConfigs.Count; i++)
        {
            var enemyData = enemyConfigs[i];
            var enemyRoot = new GameObject(enemyData.EnemyType.ToString()).transform;

            var pool = Object.Instantiate(enemyData.Pool, enemyRoot);
            var explosionPool = Object.Instantiate(enemyData.ExplosionPool, enemyRoot);

            explosionPool.Initialize();
            pool.SetData(mapBoundaries, enemyData.MoveSpeed, enemyData.EnemyType, enemyData.Score,
                players, enemyData.CustomConfigData, explosionPool);
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
