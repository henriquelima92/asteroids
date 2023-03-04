using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BigSaucerShot : SaucerShot
{
    private List<PlayerShip> _players;

    public BigSaucerShot(Transform anchor, float shotSpeed, float shotCadence, EnemyShotPool shotPool, List<PlayerShip> players) : base(anchor, shotSpeed, shotCadence, shotPool)
    {
        _players = players;
    }

    public override void Update()
    {
        CooldownTime += Time.deltaTime;

        if (ShotCadence > CooldownTime || !HasAlivePlayers())
        {
            return;
        }

        CooldownTime = 0;

        var closestPlayerPosition = GetClosestAlivePlayerPosition();
        var direction = closestPlayerPosition - Anchor.position;

        Shot(direction);
    }

    private bool HasAlivePlayers()
    {
        foreach (var player in _players)
        {
            if(player.Life.IsAlive)
            {
                return true;
            }
        }

        return false;
    }

    private Vector3 GetClosestAlivePlayerPosition()
    {
        var players = new List<PlayerShip>(_players);
        var orderedPlayersByDistance = players.Where(player => player.Life.IsAlive).
            OrderBy(player => Vector3.Distance(Anchor.position, player.transform.position)).ToArray();

        if(orderedPlayersByDistance == null)
        {
            return Vector2.zero;
        }

        var player = orderedPlayersByDistance[0];
        return player != null ? player.transform.position : Vector2.zero;
    }
}