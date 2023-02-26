public class ShotPool : GenericObjectPool<Shot>
{
    public void SetData(MapBoundaries mapBoundaries, float lifeSpan)
    {
        foreach (var item in PooledItems)
        {
            item.Set(mapBoundaries);
            item.Initialize(lifeSpan, OnShotDestroy);
        }
    }

    private void OnShotDestroy(Shot shot)
    {
        ReturnToPool(shot);
    }
}
