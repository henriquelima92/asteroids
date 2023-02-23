using System;
using System.Collections.Generic;

[Serializable]
public struct EnemyWave
{
    public int ScoreThreshold;
    public List<EnemyRange> Enemies;

    public int FindEnemyRandomRange(EnemyType type)
    {
        return Enemies.Find(x => x.EnemyType == type).Range.GetRandomRange();
    }
}
