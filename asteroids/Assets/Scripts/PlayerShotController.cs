using System;
using UnityEngine;

[Serializable]
public class PlayerShotController : ShotControllerBase
{
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
