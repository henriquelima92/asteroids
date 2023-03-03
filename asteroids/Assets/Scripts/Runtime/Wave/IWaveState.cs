public interface IWaveState
{
    public int EnemyLayers { get; }
    public int EnemiesCount { get; set; }
    public int WavesAmount { get; }
    public int CurrentWave { get; }
    public float StartDelay { get; }

    void GoToNextWave();
    void Reset();
}
