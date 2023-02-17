using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : MonoBehaviour
{
    [SerializeField] private Mover _movement;
    [SerializeField] private PlayerRotator _rotation;
    [SerializeField] private PlayerShooter _shooter;
    [SerializeField] private Life _life;

    public void InitializeShotSystem(float shotSpeed, float shotCadence, ObjectPool shotPool)
    {
        _shooter.Initialize(shotSpeed, shotCadence, shotPool);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            _rotation.SetDirectionState(DirectionState.Left);
        }

        else if (Input.GetKey(KeyCode.RightArrow))
        {
            _rotation.SetDirectionState(DirectionState.Right);
        }
        else
        {
            _rotation.SetDirectionState(DirectionState.None);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            _movement.SetMovingState(MovingState.Thrusting);
        }
        else
        {
            _movement.SetMovingState(MovingState.Idle);
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            _shooter.Shot(transform.up);
        }

        _shooter.IncrementCooldown();
    }

    private void FixedUpdate()
    {
        _movement.Move(transform.up);
        _rotation.Rotate();
    }
}
