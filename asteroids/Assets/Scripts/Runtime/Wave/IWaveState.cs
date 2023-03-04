public interface IWaveState
{
    public int EnemyLayers { get; }
    public int EnemiesCount { get; set; }
    public int WavesAmount { get; }
    public int CurrentWave { get; }
    public float StartDelay { get; }
    public bool StartFlowEnemies { get; }
    public bool StartRandomAppearanceEnemies { get; }

    void GoToNextWave();
    void Reset();
}
