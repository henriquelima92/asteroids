using System;
using UnityEngine;

[Serializable]
public abstract class ShotSystem : IShooter
{
    [field: SerializeField] public Transform ShotRoot { get; protected set; }
    [field: SerializeField] public GameObject ShotPrefab { get; protected set; }
    public float ShotSpeed { get; protected set; }
    public float ShotCadence { get; protected set; }
    public float CooldownTime { get; protected set; }


    public abstract void Shot(Vector3 direction);
   
    public void IncrementCooldown()
    {
        CooldownTime += Time.deltaTime;
    }

    public void Initialize(float shotSpeed, float shotCadence)
    {
        ShotCadence = shotCadence;
        CooldownTime = shotCadence;
        ShotSpeed = shotSpeed;
    }
}
