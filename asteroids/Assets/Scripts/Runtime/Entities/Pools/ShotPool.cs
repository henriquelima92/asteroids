public class ShotPool : GenericObjectPool<Shot>
{
    public void SetData(MapBoundaries mapBoundaries, float lifeSpan, IHighscore highscore)
    {
        foreach (var item in PooledItems)
        {
            item.Set(mapBoundaries);
            item.Initialize(lifeSpan, OnShotDestroy, highscore);
        }
    }

    private void OnShotDestroy(Shot shot)
    {
        ReturnToPool(shot);
    }
}
