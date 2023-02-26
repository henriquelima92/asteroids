using UnityEngine;

public interface IShooter
{
    public Transform Anchor { get; }
    public ShotPool ShotPool { get; }
    public float ShotSpeed { get; }
    public float ShotCadence { get; }
    public float CooldownTime { get; }


    public void Shot(Vector3 direction);
    public void IncrementCooldown();
    public void Reset();
}
