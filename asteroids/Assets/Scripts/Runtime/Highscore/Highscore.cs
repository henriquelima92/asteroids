using System;

[Serializable]
public class Highscore : IHighscore
{
    public Action<int> OnHighscoreSet { get; set; }
    public int CurrentHighscore { get; private set; }

    public void IncrementHighscore(int valueToAdd)
    {
        CurrentHighscore += valueToAdd;
        OnHighscoreSet?.Invoke(CurrentHighscore);
    }

    public void Reset()
    {
        CurrentHighscore = 0;
    }
}
