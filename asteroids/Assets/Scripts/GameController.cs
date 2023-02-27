using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private UIController _uiController;
    
    [SerializeField] private GameData _singlePlayerGameData;
    [SerializeField] private GameData _coopGameData;

    private PlayersController _playersController;
    private EnemiesController _enemiesController;
    
    private IHighscore _highscore;
    private IScoreBonus _scoreBonus;

    public GameData StartGame(bool isSinglePlayer)
    {
        var gameData = isSinglePlayer ? _singlePlayerGameData : _coopGameData;

        _highscore = new Highscore();
        _scoreBonus = new LifeScoreBonus(gameData.HighscoreConfig.ScoreNewLifeThreshold);

        _playersController = new PlayersController();
        _playersController.Initialize(gameData.PlayerData, gameData.MapBoundariesData, this);

        _enemiesController = new EnemiesController();
        _enemiesController.Initialize(gameData.EnemiesData, gameData.WaveData, gameData.MapBoundariesData, this);

        return gameData;
    }
    public void ResetGame()
    {
        _highscore.Reset();
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
    public void IncrementHighscore(int valueToAdd)
    {
        _highscore.IncrementHighscore(valueToAdd);

        if(_scoreBonus.IsBonusAvailable(_highscore.CurrentHighscore))
        {
            _playersController.IncrementPlayersLife();
        }
    }

    private void GameOver()
    {
        _uiController.OnGameplayFinish();
    }
}
