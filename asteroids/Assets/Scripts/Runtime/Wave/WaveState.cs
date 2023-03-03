using UnityEngine;

public class WaveState : IWaveState
{
    public int EnemyLayers { get; }

    public int EnemiesCount { get; set; }

    public int CurrentWave { get; private set; }

    public float StartDelay { get; private set; }

    public int WavesAmount { get; private set; }

    public WaveState(float startDelay, int wavesAmount, int enemyLayers)
    {
        EnemyLayers = enemyLayers;
        WavesAmount = wavesAmount;
        StartDelay = startDelay;
        CurrentWave = 0;
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
