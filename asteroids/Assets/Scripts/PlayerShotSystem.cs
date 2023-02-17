using System;
using UnityEngine;

[Serializable]
public class PlayerShotSystem : ShotSystem
{
    public override void Shot(Vector3 direction)
    {
        if (ShotCadence > CooldownTime)
        {
            return;
        }

        CooldownTime = 0;

        // TODO: change the instantiate method to object pool
        var shot = GameObject.Instantiate(ShotPrefab, ShotRoot.position, Quaternion.identity);
        var shotRigidBody = shot.GetComponent<Rigidbody2D>();
        shotRigidBody.AddForce(direction * ShotSpeed, ForceMode2D.Impulse);
    }
}
