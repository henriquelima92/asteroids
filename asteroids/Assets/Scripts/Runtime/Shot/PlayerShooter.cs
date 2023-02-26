using System;
using UnityEngine;

[Serializable]
public class PlayerShooter : ShotControllerBase
{

    public PlayerShooter(Transform anchor, float shotSpeed, float shotCadence, ShotPool shotPool) : 
        base(anchor, shotSpeed, shotCadence, shotPool) { }

    public override void Shot(Vector3 direction)
    {
        if (ShotCadence > CooldownTime)
        {
            return;
        }

        CooldownTime = 0;

        var shot = ShotPool.GetFromPool();
        shot.Move(Anchor.position, direction, ShotSpeed);
    }
}
