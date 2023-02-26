using UnityEngine;
using UnityEngine.Events;

public class PlayerShip : Entity
{
    public ILife Life => _life;
    
    private IMovement _movement;
    private IRotator _rotation;
    private IShooter _shooter;
    private ILife _life;
    private PlayerInputs _inputs;

    private UnityAction<PlayerShip> _onDestroy;


    public void Initialize(IMovement movement, IRotator rotator, IShooter shooter, 
        ILife life, PlayerInputs inputs, MapBoundaries mapBoundaries)
    {
        Set(mapBoundaries);

        _movement = movement;
        _rotation = rotator;
        _shooter = shooter;
        _life = life;
        _inputs = inputs;
    }

    protected override void Update()
    {
        base.Update();

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var collisionLayer = collision.gameObject.layer;

        if (collisionLayer == LayerMask.NameToLayer(EntityUtility.Asteroid))
        {
            _life.RemoveLife();
            gameObject.SetActive(false);
        }
    }
}
