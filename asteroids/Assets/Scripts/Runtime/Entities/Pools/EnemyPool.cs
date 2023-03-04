using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class EnemyPool : GenericObjectPool<Enemy>
{
    protected EnemyRangeConfig EnemyRangeConfig;
    protected MapBoundaries MapBoundaries;
    protected FloatRange SpeedRange;
    protected EnemyType EnemyType;
    protected int Score;
    protected IWaveState WaveState;
    protected List<PlayerShip> Players;
    protected CustomConfigData CustomConfigData;
    protected UnityAction<Enemy> OnDestroy;

    public void SetData(MapBoundaries mapBoundaries, FloatRange speedRange, EnemyType enemyType, int score, List<PlayerShip> players,
        CustomConfigData customConfigData)
    {
        MapBoundaries = mapBoundaries;
        SpeedRange = speedRange;
        EnemyType = enemyType;
        Score = score;
        Players = players;
        CustomConfigData = customConfigData;

        OnCreateNewPooledItem = OnCreatePoolItem;
    }
    public void Initialize(IWaveState waveState, UnityAction<Enemy> onDestroy = null)
    {
        WaveState = waveState;
        OnDestroy = onDestroy;

        void OnEnemyDestroyed(Enemy enemy)
        {
            ReturnToPool(enemy);
            OnDestroy?.Invoke(enemy);
        }

        foreach (var item in PooledItems)
        {
            item.Set(MapBoundaries);
            item.Initialize(Score, OnEnemyDestroyed);
        }
    }
    

    public abstract void StartEnemy(Enemy enemy = null);

    public virtual void StopEnemy() { }

    public virtual void SetWaveConfig(EnemyWaveConfig waveConfig) 
    {
        EnemyRangeConfig = waveConfig.FindEnemyRange(EnemyType);
    }
    public virtual void ResetPool()
    {
        Destroy(gameObject);
    }

    public virtual void OnCreatePoolItem(Enemy enemy)
    {
        void OnEnemyDestroyed(Enemy enemy)
        {
            ReturnToPool(enemy);
            OnDestroy?.Invoke(enemy);
        }

        enemy.Set(MapBoundaries);
        enemy.Initialize(Score, OnEnemyDestroyed);
    }
}
