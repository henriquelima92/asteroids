using UnityEngine;
using UnityEngine.Events;

public abstract class EnemyPool : GenericObjectPool<Enemy>
{
    protected EnemyRangeConfig EnemyRangeConfig;
    protected MapBoundaries MapBoundaries;
    protected FloatRange SpeedRange;
    protected EnemyType EnemyType;
    protected int Score;

    public void SetData(MapBoundaries mapBoundaries, FloatRange speedRange, EnemyType enemyType, int score)
    {
        MapBoundaries = mapBoundaries;
        SpeedRange = speedRange;
        EnemyType = enemyType;
        Score = score;
    }
    public void Initialize(UnityAction<Enemy> onDestroy)
    {
        void OnEnemyDestroyed(Enemy asteroid)
        {
            ReturnToPool(asteroid);
            onDestroy?.Invoke(asteroid);
        }

        foreach (var item in PooledItems)
        {
            item.Set(MapBoundaries);
            item.Initialize(Score, OnEnemyDestroyed);
        }
    }
    

    public abstract int StartEnemy(Enemy enemy = null);
    public virtual void SetWaveConfig(EnemyWaveConfig waveConfig) 
    {
        EnemyRangeConfig = waveConfig.FindEnemyRange(EnemyType);
    }
    public virtual void ResetPool()
    {
        Destroy(gameObject);
    }
}
