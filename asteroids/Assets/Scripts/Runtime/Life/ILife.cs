public interface ILife
{
    public int StartLives { get; }
    public int Lives { get; }
    public int MaxLives { get; }
    public bool IsAlive { get; }

    public int RemoveLife();
    public int AddLife();

    public void Reset();
}