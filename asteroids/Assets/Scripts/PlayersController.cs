﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayersController
{
    private List<PlayerShip> _players;

    public List<PlayerShip> Initialize(
        PlayerData playerData, 
        MapBoundariesData mapBoundariesData, 
        HighscoreConfig highscoreConfig, 
        GameController gameController,
        UnityAction onDestroyAsteroid,
        UnityAction onAddLife)
    {
        _players = new List<PlayerShip>();

        var players = playerData.Players;
        var mapBoundaries = mapBoundariesData.MapBoundaries;

        foreach (var player in players)
        {
            var shotConfig = player.ShotConfig;
            var playerShip = Object.Instantiate(player.PlayerPrefab, player.StartPosition, Quaternion.identity);
            var shotPool = Object.Instantiate(shotConfig.Pool);

            IMovement movement = new Mover(playerShip.Rigidbody, player.MoveSpeed, player.StartPosition);
            IRotator rotator = new PlayerRotator(playerShip.Rigidbody, player.RotateSpeed);
            IShooter shooter = new PlayerShooter(playerShip.transform, player.ShotConfig.ShotSpeed, player.ShotConfig.ShotCadence, shotPool);
            ILife life = new Life(player.Lives, player.MaxLives);
            IRespawn respawn = new PlayerRespawn(4f);
            IHighscore highscore = new Highscore();
            IScoreBonus scoreBonus = new LifeScoreBonus(highscoreConfig.ScoreNewLifeThreshold, highscore, life);

            shotPool.SetData(mapBoundaries, shotConfig.ShotLifeSpan, highscore);
            playerShip.Initialize(movement, rotator, shooter, life, player.Inputs, mapBoundaries, respawn, highscore, scoreBonus, gameController);
            _players.Add(playerShip);
        }

        return _players;
    }

    public void ResetPlayers()
    {
        foreach (var player in _players)
        {
            player.ResetShip();
        }
    }

    public bool HasAlivePlayers()
    {
        bool hasPlayersAlive = false;

        foreach (var player in _players)
        {
            hasPlayersAlive = player.Life.IsAlive;
        }

        return hasPlayersAlive;
    }
}
