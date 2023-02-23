using UnityEngine;

public class PlayerShip : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    public Rigidbody2D Rigidbody2D => _rigidbody2D;
    
    private IMovement _movement;
    private IRotator _rotation;
    private IShooter _shooter;
    private ILife _life;
    private PlayerInputs _inputs;


    public void Initialize(IMovement movement, IRotator rotator, IShooter shooter, ILife life, PlayerInputs inputs)
    {
        _movement = movement;
        _rotation = rotator;
        _shooter = shooter;
        _life = life;
        _inputs = inputs;
    }

    private void Update()
    {
        if (Input.GetKey(_inputs.RotateLeft))
        {
            _rotation.SetDirectionState(DirectionState.Left);
        }

        else if (Input.GetKey(_inputs.RotateRight))
        {
            _rotation.SetDirectionState(DirectionState.Right);
        }
        else
        {
            _rotation.SetDirectionState(DirectionState.None);
        }

        if (Input.GetKey(_inputs.Thrust))
        {
            _movement.SetMovingState(MovingState.Thrusting);
        }
        else
        {
            _movement.SetMovingState(MovingState.Idle);
        }

        if(Input.GetKeyDown(_inputs.Shot))
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
