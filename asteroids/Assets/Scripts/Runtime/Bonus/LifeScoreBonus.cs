using System;
using UnityEngine.Events;

public class LifeScoreBonus : IScoreBonus
{
    private readonly IHighscore _highscore;
    private readonly ILife _life;

    private int _scoreThreshold;
    private int _thresholdIndex;

    public LifeScoreBonus(int scoreThreshold, IHighscore highScore, ILife life)
    {
        _highscore = highScore;
        _life = life;
        _scoreThreshold = scoreThreshold;
        _thresholdIndex = 1;

        highScore.OnHighscoreSet += (score) => CheckBonus();
    }

    public void CheckBonus()
    {
        if(_highscore.CurrentHighscore >= _scoreThreshold * _thresholdIndex)
        {
            _thresholdIndex += 1;
            _life.AddLife();
        }
    }

    public void Reset()
    {
        _thresholdIndex = 1;
    }
}
