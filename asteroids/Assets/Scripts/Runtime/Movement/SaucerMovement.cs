using UnityEngine;

public class SaucerMovement : IMovement
{
    public MovingState MovingState { get; private set; }
    public float Speed { get; private set; }
    public Vector2 StartPostion { get; private set; }

    private Rigidbody2D _rigidbody;
    private SaucerEnemyConfig _saucerConfig;

    private Vector2 _horizontalDirection = Vector2.zero;
    private Vector2 _verticalDirection = Vector2.zero;
   
    private float _time;
    private float _timeToChangeDirection;

    public SaucerMovement(Rigidbody2D rigidbody, float speed, Vector2 startPosition, SaucerEnemyConfig saucerConfig)
    {
        _rigidbody = rigidbody;
        _rigidbody.transform.position = startPosition;
        _saucerConfig = saucerConfig;

        Speed = speed;
        StartPostion = startPosition;

        _timeToChangeDirection = Random.Range(_saucerConfig.RangeTimeToChangeDirection.Min, _saucerConfig.RangeTimeToChangeDirection.Max);
    }

    public void Move(Vector3 direction, ForceMode2D forceMode = ForceMode2D.Force)
    {
        if (MovingState != MovingState.Thrusting)
        {
            return;
        }

        _horizontalDirection = direction;

        _rigidbody.AddForce(direction * Speed, forceMode);
    }

    public void Reset()
    {
        MovingState = MovingState.Idle;

        _rigidbody.velocity = Vector3.zero;
        _rigidbody.angularVelocity = 0f;
        _rigidbody.transform.position = StartPostion;

        _time = 0;
    }

    public void SetMovingState(MovingState state)
    {
        MovingState = state;
    }

    public void UpdateMovement()
    {
        if (_rigidbody.velocity.magnitude > Speed)
        {
            _rigidbody.velocity = _horizontalDirection + _verticalDirection * Speed;
        }           

        _time += Time.deltaTime;

        if(_time > _timeToChangeDirection)           
        {
            Debug.Log("Trying To change direction");

            var shouldGoStraight = RandomUtility.CanDo(50);

            if(!shouldGoStraight)
            {
                if (_verticalDirection != Vector2.zero)
                {
                    _verticalDirection = _verticalDirection == Vector2.up ? Vector2.down : Vector2.up;
                }
                else
                {
                    _verticalDirection = RandomUtility.CanDo(50) ? Vector2.up : Vector2.down;                   
                }                
            }
            else
            {
                _verticalDirection = Vector2.zero;
            }

            Move(_horizontalDirection + _verticalDirection, ForceMode2D.Impulse);

            _timeToChangeDirection = Random.Range(_saucerConfig.RangeTimeToChangeDirection.Min, _saucerConfig.RangeTimeToChangeDirection.Max);
            _time = 0;
        }
    }
}
