using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameData _gameData;
    [SerializeField] private HyperSpace _hyperSpace;
    [SerializeField] private PlayersController _playersController;
    [SerializeField] private EnemiesController _enemiesController;

    private List<GameObject> _entities = new List<GameObject>();

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        _hyperSpace.DrawGizmosBoundary();    
    }
#endif

    private void Start()
    {
        _playersController = new PlayersController();
        var player = _playersController.Initialize(_gameData.PlayerData);
        _entities.AddRange(player);

        _enemiesController = new EnemiesController();
        var asteroids = _enemiesController.Initialize(_gameData.EnemiesData, _gameData.WaveData, _gameData.MapBoundariesData);
        _entities.AddRange(asteroids);

        _hyperSpace.Initialize(_gameData.MapBoundariesData, _entities);
    }

    private void Update()
    {
        _hyperSpace.UpdateHyperSpace();
    }
}
