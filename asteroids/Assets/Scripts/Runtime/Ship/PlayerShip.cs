using UnityEngine;
using UnityEngine.Events;


public class PlayerShip : Entity
{
    public ILife Life => _life;
    private IMovement _movement;
    private IRotator _rotation;
    private IShooter _shooter;
    private ILife _life;
    private IRespawn _respawn;
    private PlayerInputs _inputs;

    private HyperSpace _hyperSpace;
    private UnityAction<PlayerShip> _onDestroy;
    private GameController _gameController;


    public void Initialize(IMovement movement, IRotator rotator, IShooter shooter, 
        ILife life, PlayerInputs inputs, MapBoundaries mapBoundaries, IRespawn respawn, GameController gameController)
    {
        Set(mapBoundaries);

        _movement = movement;
        _rotation = rotator;
        _shooter = shooter;
        _life = life;
        _inputs = inputs;
        _respawn = respawn;
        _hyperSpace = new HyperSpace(mapBoundaries, transform);
        _gameController = gameController;
    }

    public void ResetShip()
    {
        transform.rotation = Quaternion.identity;

        _movement.Reset();
        _rotation.Reset();
        _shooter.Reset();
        _life.Reset();
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

        if(Input.GetKeyDown(_inputs.HyperSpace))
        {
            _hyperSpace.GoToHyperSpace();
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
            var lifeAmount = _life.RemoveLife();
            gameObject.SetActive(false);

            if(_life.IsAlive)
            {
                _gameController.StartCoroutine(_respawn.Respawn(OnRespawn));
            }
        }
    }

    private void OnRespawn()
    {
        _movement.Reset();
        _rotation.Reset();

        gameObject.SetActive(true);
    }
}
