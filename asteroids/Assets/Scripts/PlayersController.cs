using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayersController
{
    public List<GameObject> Initialize(PlayerData playerData)
    {
        var players = playerData.Players;
        var entities = new List<GameObject>();

        foreach (var player in players)
        {
            var playerRoot = new GameObject(player.PlayerName).transform;

            var ship = UnityEngine.Object.Instantiate(player.PlayerPrefab, player.StartPosition, Quaternion.identity, playerRoot);
            var shotPool = new ObjectPool(player.ShotPrefab, 20, $"{player.PlayerName}_Shots", playerRoot);
            var shots = shotPool.Initialize();
            entities.AddRange(shots);

            IMovement movement = new Mover(ship.Rigidbody2D, player.MoveSpeed);
            IRotator rotator = new PlayerRotator(ship.Rigidbody2D, player.RotateSpeed);
            IShooter shooter = new PlayerShooter(ship.transform, player.ShotSpeed, player.ShotCadence, shotPool);
            ILife life = new Life();

            ship.Initialize(movement, rotator, shooter, life, player.Inputs);
            entities.Add(ship.gameObject);
        }

        return entities;
    }
}
