using System;

[Serializable]
public class SaucerEnemyConfig
{
    public EnemyShotPool Pool;
    public FloatRange RangeTimeToChangeDirection;

    public float ShotLifeSpan;
    public float ShotSpeed;
    public float ShotCadence;
}
