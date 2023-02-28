using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private UIController _uiController;
    
    [SerializeField] private GameData _singlePlayerGameData;
    [SerializeField] private GameData _coopGameData;

    private PlayersController _playersController;
    private EnemiesController _enemiesController;

    public List<PlayerShip> StartGame(bool isSinglePlayer)
    {
        var gameData = isSinglePlayer ? _singlePlayerGameData : _coopGameData;

        _enemiesController = new EnemiesController();
        _enemiesController.Initialize(gameData.EnemiesData, gameData.WaveData, gameData.MapBoundariesData, this);

        _playersController = new PlayersController();
        var playerShips = _playersController.Initialize(gameData.PlayerData, gameData.MapBoundariesData, gameData.HighscoreConfig, this);

        return playerShips;
    }
    public void ResetGame()
    {
        _enemiesController.ResetEnemies();
        _playersController.ResetPlayers();
    }
    public void CheckGameOver()
    {
        if(!_playersController.HasAlivePlayers())
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        _uiController.OnGameplayFinish();
    }
}
