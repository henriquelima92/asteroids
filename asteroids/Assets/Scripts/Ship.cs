using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ship : MonoBehaviour, IMovement, IRotator, ILife
{
    [field: SerializeField] public float Speed { get; protected set; }
    [field: SerializeField] public float RotationSpeed { get; protected set; }

    public MovingState MovingState { get; protected set; }
    public DirectionState RotationState { get; protected set; }

    public int Lives { get; protected set; }

    public int MaxLives { get; protected set; }

    
    public abstract void Move();

    public abstract void Rotate(DirectionState direction);


    public int AddLife()
    {
        Lives = Mathf.Clamp(Lives + 1, 0, MaxLives);
        return Lives;
    }

    public int RemoveLife()
    {
        Lives = Mathf.Clamp(Lives - 1, 0, MaxLives);
        return Lives;
    }


}
