using UnityEngine;
using UnityEngine.Events;

public class ExplosionPool : GenericObjectPool<Explosion>
{
    public void Initialize()
    {
        OnCreateNewPooledItem = OnDestroyExplosion;

        foreach (var explosion in PooledItems)
        {
            explosion.SetData(OnDestroyExplosion);
        }
    }

    public void Explode(Vector3 position)
    {
        var explosion = GetFromPool();
        explosion.gameObject.SetActive(true);

        explosion.StartExplosion(position);
    }

    public void ResetPool()
    {
        Destroy(gameObject);
    }

    private void OnDestroyExplosion(Explosion explosion)
    {
        ReturnToPool(explosion);
    }
}
