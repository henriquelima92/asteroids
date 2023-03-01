using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyWave", menuName = "Data/Waves/EnemyWave", order = 1)]
public class WavesData : ScriptableObject
{
    [SerializeField] private List<EnemyType> _enemiesFlow;
    [SerializeField] private List<EnemyWaveConfig> _waves;

    public List<EnemyType> EnemiesFlow => _enemiesFlow;
    public List<EnemyWaveConfig> Waves => _waves;
}
