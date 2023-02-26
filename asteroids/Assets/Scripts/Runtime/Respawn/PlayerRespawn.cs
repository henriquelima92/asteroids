using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class PlayerRespawn : IRespawn
{
    public PlayerRespawn(float timeToRespawn)
    {
        RespawnTime = timeToRespawn;
    }

    public float RespawnTime { get; private set; }

    public IEnumerator Respawn(UnityAction onFinish)
    {
        yield return new WaitForSeconds(RespawnTime);
        onFinish?.Invoke();
    }
}
