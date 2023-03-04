using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GenericObjectPool<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private int _initialCount;
    [SerializeField] protected T _prefab;

    public Queue<T> PooledItems = new Queue<T>();
    public List<T> ItemsInUse = new List<T>();

    public UnityAction<T> OnCreateNewPooledItem;

    protected virtual void Awake()
    {
        InitializePool(_initialCount);
    }

    protected virtual void InitializePool(int count)
    {
        for (int i = 0; i < count; i++)
        {
            var item = Instantiate<T>(_prefab, this.transform);
            item.gameObject.SetActive(false);
            PooledItems.Enqueue(item);
        }
    }

    public virtual T GetFromPool()
    {
        if(PooledItems.Count > 0)
        {
            T toReturn = PooledItems.Dequeue();
            ItemsInUse.Add(toReturn);
            toReturn.gameObject.SetActive(true);
            return toReturn;
        }

        return CreateNewPooledItem();
    }

    protected virtual T CreateNewPooledItem()
    {
        T newPooledItem = Instantiate(_prefab, this.transform);
        ItemsInUse.Add(newPooledItem);
        OnCreateNewPooledItem.Invoke(newPooledItem);

        return newPooledItem;
    }

    public virtual void ReturnToPool(T item)
    {
        item.gameObject.SetActive(false);
        PooledItems.Enqueue(item);
        ItemsInUse.Remove(item);
    }

    public virtual void ReturnAllItemsToPool()
    {
        foreach (var item in ItemsInUse)
        {
            item.gameObject.SetActive(false);
            PooledItems.Enqueue(item);
        }

        ItemsInUse.Clear();
    }
}
