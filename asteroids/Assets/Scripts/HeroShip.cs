using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroShip : MonoBehaviour
{
    [SerializeField] private PlayerShip _ship;
    [SerializeField] private ShotSystem _shotSystem;

    private void Start()
    {
        _shotSystem.Initialize(10f, 0.2f);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            _ship.SetDirectionState(DirectionState.Left);
        }

        else if (Input.GetKey(KeyCode.RightArrow))
        {
            _ship.SetDirectionState(DirectionState.Right);
        }
        else
        {
            _ship.SetDirectionState(DirectionState.None);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            _ship.SetMovingState(MovingState.Thrusting);
        }
        else
        {
            _ship.SetMovingState(MovingState.Idle);
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            _shotSystem.Shot(transform.up);
        }

        _shotSystem.IncrementCooldown();
    }

    private void FixedUpdate()
    {
        _ship.Move(transform.up);
        _ship.Rotate(_ship.RotationState);
    }
}
