using System;
using UnityEngine;

[Serializable]
public class PlayerShip : Ship
{
    [SerializeField] private Rigidbody2D _rigidbody;


    public override void Move(Vector3 direction)
    {
        if(MovingState != MovingState.Thrusting)
        {
            return;
        }

        _rigidbody.AddForce(direction * Speed);
    }
    public override void Rotate(DirectionState direction)
    {
        if(RotationState == DirectionState.None)
        {
            return;
        }

        _rigidbody.AddTorque((int)direction * RotationSpeed);
    }

}
