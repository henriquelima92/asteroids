using System;

public interface IHighscore
{
    public Action<int> OnHighscoreSet { get; set; }
    public int CurrentHighscore { get; }

    void IncrementHighscore(int valueToAdd);
    void Reset();
}
