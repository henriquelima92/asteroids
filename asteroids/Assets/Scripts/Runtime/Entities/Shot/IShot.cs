using UnityEngine;

public interface IShot
{
    public Transform Anchor { get; }
    public float ShotSpeed { get; }
    public float ShotCadence { get; }
    public float CooldownTime { get; }


    public void Shot(Vector3 direction);
    public void Update();
    public void Reset();

}
