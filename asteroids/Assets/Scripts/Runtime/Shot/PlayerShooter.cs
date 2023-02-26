using System;
using UnityEngine;

[Serializable]
public class PlayerShooter : ShotControllerBase
{
    private MapBoundaries _mapBoundaries;
    private float _shotLifeSpan;

    public PlayerShooter(Transform anchor, float shotSpeed, float shotCadence, float shotLifeSpan, ObjectPool shotPool, MapBoundaries mapBoundaries) : base(anchor, shotSpeed, shotCadence, shotPool)
    {
        _mapBoundaries = mapBoundaries;
        _shotLifeSpan = shotLifeSpan;
    }

    public override void Shot(Vector3 direction)
    {
        if (ShotCadence > CooldownTime)
        {
            return;
        }

        CooldownTime = 0;

        var shot = ShotPool.GetObjectFromPool<Shot>();
        shot.Initialize(_shotLifeSpan);
        shot.Set(_mapBoundaries);
        shot.Move(Anchor.position, direction, ShotSpeed);
    }
}
