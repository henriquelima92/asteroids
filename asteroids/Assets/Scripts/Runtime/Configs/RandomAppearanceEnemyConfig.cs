using System;

[Serializable]
public struct RandomAppearanceEnemyConfig
{
    public EnemyType EnemyType;
    public FloatRange TimeToAppear;
    public float AppearanceProbability;
    public float ShotProbability;
}
