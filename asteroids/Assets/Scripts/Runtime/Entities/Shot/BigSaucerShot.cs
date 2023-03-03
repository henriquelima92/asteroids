using System.Collections.Generic;
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

        if (ShotCadence > CooldownTime)
        {
            return;
        }

        CooldownTime = 0;

        var direction = RandomUtility.GetRandomDirection();
        Shot(direction);
    }
}