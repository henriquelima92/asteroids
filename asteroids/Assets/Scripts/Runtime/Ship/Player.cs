﻿using System;
using UnityEngine;

[Serializable]
public struct Player
{
    public string PlayerName;

    public PlayerShip PlayerPrefab;
    public GameObject ShotPrefab;

    public PlayerInputs Inputs;

    public float MoveSpeed;
    public float RotateSpeed;

    public float ShotCadence;
    public float ShotSpeed;
    public float ShotLifeSpan;

    public int Lives;
    public int MaxLives;

    public Vector2 StartPosition;
}
