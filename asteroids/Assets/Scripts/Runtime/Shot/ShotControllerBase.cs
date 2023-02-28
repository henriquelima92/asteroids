using System;
using UnityEngine;

[Serializable]
public abstract class ShotControllerBase : IShooter
{
    [field: SerializeField] public Transform Anchor { get; protected set; }
    public float ShotSpeed { get; protected set; }
    public float ShotCadence { get; protected set; }
    public float CooldownTime { get; protected set; }
    public ShotPool ShotPool { get; protected set;}

    public abstract void Shot(Vector3 direction);
   
    public void IncrementCooldown()
    {
        CooldownTime += Time.deltaTime;
    }

    public ShotControllerBase(Transform anchor, float shotSpeed, float shotCadence, ShotPool shotPool)
    {
        Anchor = anchor;
        ShotCadence = shotCadence;
        CooldownTime = shotCadence;
        ShotSpeed = shotSpeed;
        ShotPool = shotPool;
    }

    public void Reset()
    {
        CooldownTime = ShotCadence;
        GameObject.Destroy(ShotPool.gameObject);
    }
}
