using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayersController
{
    private List<PlayerShip> _players;

    public void Initialize(PlayerData playerData, MapBoundariesData mapBoundariesData, GameController gameController)
    {
        _players = new List<PlayerShip>();

        var players = playerData.Players;
        var mapBoundaries = mapBoundariesData.MapBoundaries;

        foreach (var player in players)
        {
            var shotConfig = player.ShotConfig;
            var playerRoot = new GameObject(player.PlayerName).transform;

            var playerShip = UnityEngine.Object.Instantiate(player.PlayerPrefab, player.StartPosition, Quaternion.identity, playerRoot);
            var shotPool = UnityEngine.Object.Instantiate(shotConfig.Pool);
            shotPool.SetData(mapBoundaries, shotConfig.ShotLifeSpan);

            IMovement movement = new Mover(playerShip.Rigidbody, player.MoveSpeed, player.StartPosition);
            IRotator rotator = new PlayerRotator(playerShip.Rigidbody, player.RotateSpeed);
            IShooter shooter = new PlayerShooter(playerShip.transform, player.ShotConfig.ShotSpeed, player.ShotConfig.ShotCadence, shotPool);
            ILife life = new Life(player.Lives, player.MaxLives);
            IRespawn respawn = new PlayerRespawn(4f);

            playerShip.Initialize(movement, rotator, shooter, life, player.Inputs, mapBoundaries, respawn, gameController);
            _players.Add(playerShip);
        }
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
            hasPlayersAlive = player.IsAlive();
        }

        return hasPlayersAlive;
    }
}
