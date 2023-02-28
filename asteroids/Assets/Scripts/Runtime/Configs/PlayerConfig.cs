using System;
using UnityEngine;

[Serializable]
public struct PlayerConfig
{
    public string PlayerName;

    public PlayerShip PlayerPrefab;
    public GameObject ShotPrefab;

    public PlayerInputs Inputs;

    public float MoveSpeed;
    public float RotateSpeed;

    public ShotConfig ShotConfig;

    public int Lives;
    public int MaxLives;

    public Vector2 StartPosition;
}
