using System;
using UnityEngine;

[Serializable]
public class ShotSystem : IShooter
{
    [field: SerializeField] public Transform ShotRoot { get; private set; }
    [field: SerializeField] public GameObject ShotPrefab { get; private set; }
    public float ShotSpeed { get; private set; }
    public float ShotCadence { get; private set; }
    public float CooldownTime { get; private set; }

  
    public void Shot(Vector3 direction)
    {
        if(ShotCadence > CooldownTime)
        {
            return;
        }

        CooldownTime = 0;

        // TODO: change the instantiate method to object pool
        var shot = GameObject.Instantiate(ShotPrefab, ShotRoot.position, Quaternion.identity);
        var shotRigidBody = shot.GetComponent<Rigidbody2D>();
        shotRigidBody.AddForce(direction * ShotSpeed, ForceMode2D.Impulse);
    }

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
