using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameData _gameData;
    [SerializeField] private PlayersController _playersController;
    [SerializeField] private EnemiesController _enemiesController;

    private void Start()
    {
        _playersController = new PlayersController();
        _playersController.Initialize(_gameData.PlayerData, _gameData.MapBoundariesData);

        _enemiesController = new EnemiesController();
        _enemiesController.Initialize(_gameData.EnemiesData, _gameData.WaveData, _gameData.MapBoundariesData);
    }
}
