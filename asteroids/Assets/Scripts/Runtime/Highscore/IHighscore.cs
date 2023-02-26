public interface IHighscore
{
    public int CurrentHighscore { get; }

    void IncrementHighscore(int valueToAdd);
    void Reset();
}
