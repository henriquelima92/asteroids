using UnityEngine;

public enum MovingState
{
    Idle,
    Thrusting,
}

public interface IMovement
{
    public MovingState MovingState { get; }
    public float Speed { get; }
    public Vector2 StartPostion { get; }


    void SetMovingState(MovingState state);
    void Move(Vector3 direction, ForceMode2D forceMode = ForceMode2D.Force);
    void Reset();
}