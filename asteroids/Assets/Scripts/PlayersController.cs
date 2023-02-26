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
            var shotConfig = player.ShotConfig;
            var playerRoot = new GameObject(player.PlayerName).transform;

            var ship = UnityEngine.Object.Instantiate(player.PlayerPrefab, player.StartPosition, Quaternion.identity, playerRoot);
            var shotPool = UnityEngine.Object.Instantiate(shotConfig.Pool);
            shotPool.SetData(mapBoundaries, shotConfig.ShotLifeSpan);

            IMovement movement = new Mover(ship.Rigidbody, player.MoveSpeed);
            IRotator rotator = new PlayerRotator(ship.Rigidbody, player.RotateSpeed);
            IShooter shooter = new PlayerShooter(ship.transform, player.ShotConfig.ShotSpeed, player.ShotConfig.ShotCadence, shotPool);
            ILife life = new Life(player.Lives, player.MaxLives);

            ship.Initialize(movement, rotator, shooter, life, player.Inputs, mapBoundaries);

            entities.Add(ship.gameObject);
        }

        return entities;
    }
}
