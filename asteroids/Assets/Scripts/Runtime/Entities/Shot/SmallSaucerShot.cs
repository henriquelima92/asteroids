using UnityEngine;

public class SmallSaucerShot : SaucerShot
{
    public SmallSaucerShot(Transform anchor, float shotSpeed, float shotCadence, EnemyShotPool shotPool) : base(anchor, shotSpeed, shotCadence, shotPool)
    {

    }

    public override void Update()
    {
        CooldownTime += Time.deltaTime;

        if (ShotCadence > CooldownTime)
        {
            return;
        }

        CooldownTime = 0;

        var direction = RandomUtility.GetRandomDirection();
        Shot(direction);
    }
}
