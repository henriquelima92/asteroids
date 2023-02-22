using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObjectPool
{
    [SerializeField] private GameObject _objectToPool;
    [SerializeField] private int _maxAmount;
    [SerializeField] private Transform _root;

    private List<GameObject> _pooledObjects;

    public List<GameObject> Initialize()
    {
        _pooledObjects = new List<GameObject>();
        GameObject tempObject;

        for (int i = 0; i < _maxAmount; i++)
        {
            tempObject = Object.Instantiate(_objectToPool, _root);
            tempObject.SetActive(false);

            _pooledObjects.Add(tempObject);
        }

        return _pooledObjects;
    }

    public T GetObjectFromPool<T>()
    {
        T pooledObject = default;

        for (int i = 0; i < _pooledObjects.Count; i++)
        {
            if(_pooledObjects[i].activeInHierarchy == false)
            {
                pooledObject = _pooledObjects[i].GetComponent<T>();
            }
        }

        if (pooledObject == null)
        {
            var obj = Object.Instantiate(_objectToPool, _root);
            _pooledObjects.Add(obj);

            pooledObject = obj.GetComponent<T>();
        }

        return pooledObject;
    }
}
