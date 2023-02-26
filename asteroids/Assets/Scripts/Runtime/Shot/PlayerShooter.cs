using System;
using UnityEngine;

[Serializable]
public class PlayerShooter : ShotControllerBase
{
    private MapBoundaries _mapBoundaries;

    public PlayerShooter(Transform anchor, float shotSpeed, float shotCadence, ObjectPool shotPool, MapBoundaries mapBoundaries) : base(anchor, shotSpeed, shotCadence, shotPool)
    {
        _mapBoundaries = mapBoundaries;
    }

    public override void Shot(Vector3 direction)
    {
        if (ShotCadence > CooldownTime)
        {
            return;
        }

        CooldownTime = 0;

        var shot = ShotPool.GetObjectFromPool<Shot>();
        shot.Set(_mapBoundaries);
        shot.Move(Anchor.position, direction, ShotSpeed);
    }
}
