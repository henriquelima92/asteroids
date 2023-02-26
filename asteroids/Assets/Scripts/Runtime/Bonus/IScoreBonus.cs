public interface IScoreBonus
{
    bool IsBonusAvailable(int score);
    void Reset();
}
