using UnityEngine;

public class SaucerShot : IShot
{
    public Transform Anchor { get; protected set; }
    public float ShotSpeed { get; protected set; }
    public float ShotCadence { get; protected set; }
    public float CooldownTime { get; protected set; }
    public EnemyShotPool ShotPool { get; protected set; }

    public SaucerShot(Transform anchor, float shotSpeed, float shotCadence, EnemyShotPool shotPool)
    {
        Anchor = anchor;
        ShotCadence = shotCadence;
        CooldownTime = 0;
        ShotSpeed = shotSpeed;
        ShotPool = shotPool;
    }

    public virtual void Reset()
    {
        CooldownTime = ShotCadence;
        Object.Destroy(ShotPool.gameObject);
    }

    public void Shot(Vector3 direction)
    {
        var shot = ShotPool.GetFromPool();

        shot.Timer.ResetTimer();
        IMovement movement = new RigidbodyMovement(shot.Rigidbody, ShotSpeed, Anchor.position);

        shot.gameObject.SetActive(true);
        movement.SetMovingState(MovingState.Thrusting);
        movement.Move(direction, ForceMode2D.Impulse);
    }

    public virtual void Update()
    {
        
    }
}
