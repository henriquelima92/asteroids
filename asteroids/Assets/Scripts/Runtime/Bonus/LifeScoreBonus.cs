public class LifeScoreBonus : IScoreBonus
{
    private int _scoreThreshold;
    private int _thresholdIndex;

    public LifeScoreBonus(int scoreThreshold)
    {
        _scoreThreshold = scoreThreshold;
        _thresholdIndex = 1;
    }

    public bool IsBonusAvailable(int score)
    {
        if(score >= _scoreThreshold * _thresholdIndex)
        {
            _thresholdIndex += 1;
            return true;
        }

        return false;
    }

    public void Reset()
    {
        _thresholdIndex = 1;
    }
}
