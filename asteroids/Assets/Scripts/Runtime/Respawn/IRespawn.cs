using System.Collections;
using UnityEngine.Events;

public interface IRespawn
{ 
    public float RespawnTime { get; }

    IEnumerator Respawn(UnityAction onFinish);
}
