public class EnemyShotPool : GenericObjectPool<EnemyShot>
{
    public void SetData(MapBoundaries mapBoundaries, float lifeSpan)
    {
        foreach (var item in PooledItems)
        {
            item.Set(mapBoundaries);
            item.Initialize(lifeSpan, OnShotDestroy);
        }
    }

    private void OnShotDestroy(EnemyShot shot)
    {
        ReturnToPool(shot);
    }
}
