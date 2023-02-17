﻿using System;
using UnityEngine;

[Serializable]
public abstract class ShotControllerBase : IShooter
{
    [field: SerializeField] public Transform Anchor { get; protected set; }
    public float ShotSpeed { get; protected set; }
    public float ShotCadence { get; protected set; }
    public float CooldownTime { get; protected set; }
    public ObjectPool ShotPool { get; protected set;}

    public abstract void Shot(Vector3 direction);
   
    public void IncrementCooldown()
    {
        CooldownTime += Time.deltaTime;
    }

    public void Initialize(float shotSpeed, float shotCadence, ObjectPool shotPool)
    {
        ShotCadence = shotCadence;
        CooldownTime = shotCadence;
        ShotSpeed = shotSpeed;
        ShotPool = shotPool;
    }
}