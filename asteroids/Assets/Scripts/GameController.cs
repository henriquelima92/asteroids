using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private HyperSpace _hyperSpace;

    [SerializeField] private HeroShip _heroShip;
    [SerializeField] private ObjectPool _playerShotsPool;

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

        _heroShip.InitializeShotSystem(10f, 0.1f, _playerShotsPool);
        entities.Add(_heroShip.gameObject);

        _hyperSpace.Initialize(entities);
    }

    private void Update()
    {
        _hyperSpace.UpdateHyperSpace();


    }
}
