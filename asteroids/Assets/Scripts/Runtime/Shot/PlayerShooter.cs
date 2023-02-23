﻿using System;
using UnityEngine;

[Serializable]
public class PlayerShooter : ShotControllerBase
{
    public PlayerShooter(Transform anchor, float shotSpeed, float shotCadence, ObjectPool shotPool) : base(anchor, shotSpeed, shotCadence, shotPool)
    {

    }

    public override void Shot(Vector3 direction)
    {
        if (ShotCadence > CooldownTime)
        {
            return;
        }

        CooldownTime = 0;

        var shot = ShotPool.GetObjectFromPool<Rigidbody2D>();
        shot.transform.position = Anchor.position;
        shot.gameObject.SetActive(true);
        shot.AddForce(direction * ShotSpeed, ForceMode2D.Impulse);
    }
}
