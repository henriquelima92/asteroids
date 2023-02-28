using System;
using UnityEngine;

[Serializable]
public class RigidbodyRotator : IRotator
{
    [SerializeField] private Rigidbody2D _rigidbody;

    [field: SerializeField] public float RotationSpeed { get; protected set; }
    public DirectionState RotationState { get; protected set; }

    public RigidbodyRotator(Rigidbody2D rigidbody2D, float rotationSpeed)
    {
        _rigidbody = rigidbody2D;
        RotationSpeed = rotationSpeed;
    }

    public void Reset()
    {
        _rigidbody.transform.rotation = Quaternion.identity;
    }

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
