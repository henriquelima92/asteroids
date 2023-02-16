using UnityEngine;

public interface IShooter
{
    public Transform ShotRoot { get; }
    public GameObject ShotPrefab { get; }
    public float ShotSpeed { get; }
    public float ShotCadence { get; }
    public float CooldownTime { get; }


    public void Shot(Vector3 direction);
    public void IncrementCooldown();

    public void Initialize(float shotSpeed, float shotCadence);
}
