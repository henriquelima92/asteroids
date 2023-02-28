using System;
using System.Collections.Generic;

[Serializable]
public struct EnemyWaveConfig
{
    public int ScoreThreshold;
    public List<EnemyRangeConfig> Enemies;

    public int FindEnemyRandomRange(EnemyType type)
    {
        return Enemies.Find(x => x.EnemyType == type).Range.GetRandomRange();
    }
}
