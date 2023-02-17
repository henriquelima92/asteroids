using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private HyperSpace _hyperSpace;

    [SerializeField] private PlayerShip _playerShip;
    [SerializeField] private ObjectPool _playerShotsPool;

    [SerializeField] private List<ObjectPool> _asteroidsPool;

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        _hyperSpace.DrawGizmosBoundary();    
    }
#endif

    private void Start()
    {
        var entities = new List<GameObject>();

        var shots = _playerShotsPool.Initialize();
        entities.AddRange(shots);

        _playerShip.InitializeShotSystem(10f, 0.1f, _playerShotsPool);
        entities.Add(_playerShip.gameObject);

        foreach (var asteroidPool in _asteroidsPool)
        {
            var pool = asteroidPool.Initialize();
            entities.AddRange(pool);
        }

        _hyperSpace.Initialize(entities);
    }

    private void Update()
    {
        _hyperSpace.UpdateHyperSpace();


    }
}
