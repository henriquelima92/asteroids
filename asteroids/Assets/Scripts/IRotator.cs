public enum DirectionState
{
    None = 0,
    Right = -1,
    Left = 1
}

public interface IRotator
{
    public DirectionState RotationState { get; }
    public float RotationSpeed { get; }

    void Rotate(DirectionState direction);
}
