using System.Collections.Generic;
using UnityEngine;

public class PlayersController
{
    private List<PlayerShip> _players;

    public List<PlayerShip> Initialize(PlayerData playerData, MapBoundariesData mapBoundariesData, HighscoreConfig highscoreConfig, GameController gameController)
    {
        _players = new List<PlayerShip>();

        var players = playerData.Players;
        var mapBoundaries = mapBoundariesData.MapBoundaries;

        foreach(var player in players)
        {
            var playerRoot = new GameObject(player.PlayerName).transform;

            var shotConfig = player.ShotConfig;
            var playerShip = Object.Instantiate(player.PlayerPrefab, player.StartPosition, Quaternion.identity, playerRoot);
            var shotPool = Object.Instantiate(shotConfig.Pool, playerRoot);
            var explosion = Object.Instantiate(player.ExplosionPrefab, playerRoot);

            IMovement movement = new RigidbodyMovement(playerShip.Rigidbody, player.MoveSpeed, player.StartPosition);
            IRotator rotator = new RigidbodyRotator(playerShip.Rigidbody, player.RotateSpeed);
            IShot shooter = new PlayerShot(playerShip.transform, player.ShotConfig.ShotSpeed, player.ShotConfig.ShotCadence, shotPool);
            ILife life = new Life(player.Lives, player.MaxLives);
            IRespawn respawn = new PlayerRespawn(playerData.RespawnTime);
            IHighscore highscore = new Highscore();
            IScoreBonus scoreBonus = new LifeScoreBonus(highscoreConfig.ScoreNewLifeThreshold, highscore, life);

            explosion.SetData((explosion) => { explosion.gameObject.SetActive(false); });

            shotPool.SetData(mapBoundaries, shotConfig.ShotLifeSpan, highscore);
            playerShip.Initialize(movement, rotator, shooter, life, player.Inputs, 
                mapBoundaries, respawn, highscore, scoreBonus, gameController, explosion);
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
