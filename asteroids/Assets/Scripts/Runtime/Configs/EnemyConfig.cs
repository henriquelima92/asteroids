using System;

[Serializable]
public struct EnemyConfig
{
    public EnemyType EnemyType;
    public EnemyPool Pool;
    public FloatRange MoveSpeed;
    public int Score;
}
