using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : Ship
{
    [SerializeField] private Rigidbody2D _rigidbody;


    private void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            RotationState = DirectionState.Left;
        }

        else if(Input.GetKey(KeyCode.RightArrow))
        {
            RotationState = DirectionState.Right;
        }
        else
        {
            RotationState = DirectionState.None;
        }

        if(Input.GetKey(KeyCode.UpArrow))
        {
            MovingState = MovingState.Thrusting;
        }
        else
        {
            MovingState = MovingState.Idle;
        }
    }

    private void FixedUpdate()
    {
        if(MovingState == MovingState.Thrusting)
        {
            Move();
        }

        if(RotationState != DirectionState.None)
        {
            Rotate(RotationState);
        }
    }

    public override void Move()
    {
        _rigidbody.AddForce(transform.up * Speed);
    }

    public override void Rotate(DirectionState direction)
    {
        _rigidbody.AddTorque((int)direction * RotationSpeed);
    }
}
