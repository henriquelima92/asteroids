using UnityEngine;

public class WaveState : IWaveState
{
    public int EnemyLayers { get; }

    public int EnemiesCount { get; set; }

    public int CurrentWave { get; private set; }

    public float StartDelay { get; private set; }

    public int WavesAmount { get; private set; }

    public bool StartFlowEnemies { get; private set; }

    public bool StartRandomAppearanceEnemies { get; private set; }

    public WaveState(float startDelay, int wavesAmount, int enemyLayers, bool startFlowEnemies, bool startRandomAppearanceEnemies)
    {
        EnemyLayers = enemyLayers;
        WavesAmount = wavesAmount;
        StartDelay = startDelay;
        CurrentWave = 0;
        StartFlowEnemies = startFlowEnemies;
        StartRandomAppearanceEnemies = startRandomAppearanceEnemies;
    }

    public void GoToNextWave()
    {
         CurrentWave = Mathf.Clamp(CurrentWave + 1, 0, WavesAmount);
    }

    public void Reset()
    {
        CurrentWave = 0;
        EnemiesCount = 0;
    }
}
