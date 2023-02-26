using System;

[Serializable]
public class Highscore : IHighscore
{
    public int CurrentHighscore { get; private set; }

    public void IncrementHighscore(int valueToAdd)
    {
        CurrentHighscore += valueToAdd;
    }

    public void Reset()
    {
        CurrentHighscore = 0;
    }
}
