using System;
using UnityEngine;

[Serializable]
public class Mover : IMovement
{
    [SerializeField] private Rigidbody2D _rigidbody;

    public Vector2 StartPostion { get; private set; }
    [field: SerializeField] public float Speed { get; protected set; }
    public MovingState MovingState { get; protected set; }

    public Mover(Rigidbody2D rigidbody, float speed, Vector2 startPosition)
    {
        _rigidbody = rigidbody;
        _rigidbody.transform.position = startPosition;

        Speed = speed;
        StartPostion = startPosition;
    }

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

    public void Reset()
    {
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.angularVelocity = 0f;
        _rigidbody.transform.position = StartPostion;
    }
}
