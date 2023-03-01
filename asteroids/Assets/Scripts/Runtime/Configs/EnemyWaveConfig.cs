using System;
using System.Collections.Generic;

[Serializable]
public struct EnemyWaveConfig
{
    public List<EnemyRangeConfig> Enemies;
    public List<RandomAppearanceEnemyConfig> RandomAppearanceEnemies;


    public EnemyRangeConfig FindEnemyRange(EnemyType type)
    {
        return Enemies.Find(x => x.EnemyType == type);
    }

    public RandomAppearanceEnemyConfig FindRandomAppearanceEnemy(EnemyType type)
    {
        return RandomAppearanceEnemies.Find(x => x.EnemyType == type);
    }
}
