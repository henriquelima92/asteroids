using System;
using UnityEngine;

[Serializable]
public class Mover : IMovement
{
    [SerializeField] private Rigidbody2D _rigidbody;

    [field: SerializeField] public float Speed { get; protected set; }
    public MovingState MovingState { get; protected set; }

    public void Move(Vector3 direction,  ForceMode2D forceMode = ForceMode2D.Force)
    {
        if (MovingState != MovingState.Thrusting)
        {
            return;
        }

        _rigidbody.AddForce(direction * Speed, forceMode);
    }
    public void SetMovingState(MovingState state)
    {
        MovingState = state;
    }

    public Mover(Rigidbody2D rigidbody, float speed)
    {
        _rigidbody = rigidbody;
        Speed = speed;
    }
}
