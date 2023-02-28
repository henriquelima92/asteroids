using System;
using UnityEngine.Events;

public class LifeScoreBonus : IScoreBonus
{
    private readonly IHighscore _highscore;
    private readonly UnityAction _onReceiveBonus;

    private int _scoreThreshold;
    private int _thresholdIndex;

    public LifeScoreBonus(int scoreThreshold, IHighscore highScore, UnityAction onSetScore, UnityAction onReceiveBonus)
    {
        _highscore = highScore;
        _scoreThreshold = scoreThreshold;
        _thresholdIndex = 1;
        _onReceiveBonus = onReceiveBonus;

        onSetScore += CheckBonus;
    }

    public void CheckBonus()
    {
        if(_highscore.CurrentHighscore >= _scoreThreshold * _thresholdIndex)
        {
            _thresholdIndex += 1;
            _onReceiveBonus?.Invoke();
        }
    }

    public void Reset()
    {
        _thresholdIndex = 1;
    }
}
