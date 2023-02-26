using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayersController
{
    public List<GameObject> Initialize(PlayerData playerData, MapBoundariesData mapBoundariesData)
    {
        var players = playerData.Players;
        var mapBoundaries = mapBoundariesData.MapBoundaries;
        var entities = new List<GameObject>();

        foreach (var player in players)
        {
            var playerRoot = new GameObject(player.PlayerName).transform;

            var ship = UnityEngine.Object.Instantiate(player.PlayerPrefab, player.StartPosition, Quaternion.identity, playerRoot);
            var shotPool = new ObjectPool(player.ShotPrefab, 20, $"{player.PlayerName}_Shots", playerRoot);
            var shots = shotPool.Initialize();
            entities.AddRange(shots);

            IMovement movement = new Mover(ship.Rigidbody, player.MoveSpeed);
            IRotator rotator = new PlayerRotator(ship.Rigidbody, player.RotateSpeed);
            IShooter shooter = new PlayerShooter(ship.transform, player.ShotSpeed, player.ShotCadence, shotPool, mapBoundaries);
            ILife life = new Life(player.Lives, player.MaxLives);

            ship.Initialize(movement, rotator, shooter, life, player.Inputs, mapBoundaries);

            entities.Add(ship.gameObject);
        }

        return entities;
    }
}
