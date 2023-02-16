public interface ILife
{
    public int Lives { get; }
    public int MaxLives { get; }

    public int RemoveLife();
    public int AddLife();
}