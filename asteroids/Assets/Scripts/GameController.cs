using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameData _singlePlayerGameData;
    [SerializeField] private GameData _coopGameData;
    [SerializeField] private PlayersController _playersController;
    [SerializeField] private EnemiesController _enemiesController;
    
    private IHighscore _highscore;
    private IScoreBonus _scoreBonus;

    //private void Start()
    //{
    //    _highscore = new Highscore();
    //    _scoreBonus = new LifeScoreBonus(_gameData.HighscoreConfig.ScoreNewLifeThreshold);

    //    _playersController = new PlayersController();
    //    _playersController.Initialize(_gameData.PlayerData, _gameData.MapBoundariesData, this);

    //    _enemiesController = new EnemiesController();
    //    _enemiesController.Initialize(_gameData.EnemiesData, _gameData.WaveData, _gameData.MapBoundariesData, this);
    //}

    public void StartGame(bool isSinglePlayer)
    {

        var gameData = isSinglePlayer ? _singlePlayerGameData : _coopGameData;

        _highscore = new Highscore();
        _scoreBonus = new LifeScoreBonus(gameData.HighscoreConfig.ScoreNewLifeThreshold);

        _playersController = new PlayersController();
        _playersController.Initialize(gameData.PlayerData, gameData.MapBoundariesData, this);

        _enemiesController = new EnemiesController();
        _enemiesController.Initialize(gameData.EnemiesData, gameData.WaveData, gameData.MapBoundariesData, this);
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
        StartCoroutine(RestartGame());
    }

    private IEnumerator RestartGame()
    {
        var delayToRestart = 4f;
        var currentTime = 0f;

        while(currentTime < delayToRestart)
        {
            currentTime += Time.deltaTime;
            Debug.Log($"Starting in {currentTime}");
            yield return null;
        }

        ResetGame();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha9))
        {
            ResetGame();
        }
    }
}
