using UnityEngine;
using UnityEngine.Events;


public class PlayerShip : Entity
{
    public ILife Life => _life;
    public IHighscore Highscore => _highscore;

    private IMovement _movement;
    private IRotator _rotation;
    private IShot _shooter;
    private ILife _life;
    private IRespawn _respawn;
    private IHighscore _highscore;
    private IScoreBonus _scoreBonus;
    private PlayerInputs _inputs;

    private HyperSpace _hyperSpace;
    private UnityAction<PlayerShip> _onDestroy;
    private GameController _gameController;
    private Explosion _explosion;


    public void Initialize(IMovement movement, IRotator rotator, IShot shooter, 
        ILife life, PlayerInputs inputs, MapBoundaries mapBoundaries, 
        IRespawn respawn, IHighscore highscore, IScoreBonus scoreBonus, 
        GameController gameController, Explosion explosion)
    {
        Set(mapBoundaries);

        _movement = movement;
        _rotation = rotator;
        _shooter = shooter;
        _life = life;
        _inputs = inputs;
        _respawn = respawn;
        _highscore = highscore;
        _scoreBonus = scoreBonus;

        _hyperSpace = new HyperSpace(mapBoundaries, transform);
        _gameController = gameController;

        _explosion = explosion;
    }

    public void ResetShip()
    {
        _movement.Reset();
        _rotation.Reset();
        _shooter.Reset();
        _life.Reset();
        _highscore.Reset();

        Destroy(transform.parent.gameObject);
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

        _shooter.Update();
    }

    private void FixedUpdate()
    {
        _movement.Move(transform.up);
        _rotation.Rotate();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var collisionLayer = collision.gameObject.layer;

        if (collisionLayer == LayerMask.NameToLayer(EntityUtility.Asteroid) || collisionLayer == LayerMask.NameToLayer(EntityUtility.Saucer)
            || collisionLayer == LayerMask.NameToLayer(EntityUtility.EnemyShot))
        {
            _life.RemoveLife();
            gameObject.SetActive(false);

            _explosion.gameObject.SetActive(true);
            _explosion.StartExplosion(transform.position);

            if(_life.IsAlive)
            {
                _gameController.StartCoroutine(_respawn.Respawn(OnRespawn));
                return;
            }

            _gameController.CheckGameOver();
        }
    }

    private void OnRespawn()
    {
        _movement.Reset();
        _rotation.Reset();

        gameObject.SetActive(true);
    }
}
