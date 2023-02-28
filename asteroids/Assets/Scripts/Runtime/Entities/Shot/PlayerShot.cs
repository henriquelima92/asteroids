using UnityEngine;

[System.Serializable]
public class PlayerShot : IShot
{
    public Transform Anchor { get; protected set; }
    public float ShotSpeed { get; protected set; }
    public float ShotCadence { get; protected set; }
    public float CooldownTime { get; protected set; }
    public ShotPool ShotPool { get; protected set; }


    public void IncrementCooldown()
    {
        CooldownTime += Time.deltaTime;
    }

    public PlayerShot(Transform anchor, float shotSpeed, float shotCadence, ShotPool shotPool)
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
        Object.Destroy(ShotPool.gameObject);
    }

    public void Shot(Vector3 direction)
    {
        if (ShotCadence > CooldownTime)
        {
            return;
        }

        CooldownTime = 0;

        var shot = ShotPool.GetFromPool();

        shot.Timer.ResetTimer();
        IMovement movement = new RigidbodyMovement(shot.Rigidbody, ShotSpeed, Anchor.position);

        shot.gameObject.SetActive(true);
        movement.SetMovingState(MovingState.Thrusting);
        movement.Move(direction, ForceMode2D.Impulse);
    }
}
