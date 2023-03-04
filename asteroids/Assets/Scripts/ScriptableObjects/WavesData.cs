using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyWave", menuName = "Data/Waves/EnemyWave", order = 1)]
public class WavesData : ScriptableObject
{
    [SerializeField] private bool _startFlowEnemies;
    [SerializeField] private bool _startRandomAppearanceEnemies;

    [Space]

    [SerializeField] private List<EnemyType> _enemiesFlow;
    [SerializeField] private List<EnemyWaveConfig> _waves;

    public bool StartFlowEnemies => _startFlowEnemies;
    public bool StartRandomAppearanceEnemies => _startRandomAppearanceEnemies;

    public List<EnemyType> EnemiesFlow => _enemiesFlow;
    public List<EnemyWaveConfig> Waves => _waves;
}
