using System;
using UnityEngine.Events;

[Serializable]
public struct EnemyConfig
{
    public EnemyType EnemyType;
    public EnemyPool Pool;
    public FloatRange MoveSpeed;
    public int Score;

    public bool RandomAppearance;
}
