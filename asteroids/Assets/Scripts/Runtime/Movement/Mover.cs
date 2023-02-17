using System;
using UnityEngine;

[Serializable]
public class Mover : IMovement
{
    [SerializeField] private Rigidbody2D _rigidbody;

    [field: SerializeField] public float Speed { get; protected set; }
    public MovingState MovingState { get; protected set; }

    public void Move(Vector3 direction)
    {
        if (MovingState != MovingState.Thrusting)
        {
            return;
        }

        _rigidbody.AddForce(direction * Speed);
    }

    public void SetMovingState(MovingState state)
    {
        MovingState = state;
    }
}
