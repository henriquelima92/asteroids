using System;
using UnityEngine;

[Serializable]
public class PlayerRotator : IRotator
{
    [SerializeField] private Rigidbody2D _rigidbody;

    [field: SerializeField] public float RotationSpeed { get; protected set; }
    public DirectionState RotationState { get; protected set; }


    public void Rotate()
    {
        if (RotationState == DirectionState.None)
        {
            return;
        }

        _rigidbody.AddTorque((int)RotationState * RotationSpeed);
    }

    public void SetDirectionState(DirectionState direction)
    {
        RotationState = direction;
    }
}
