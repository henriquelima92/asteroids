using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Data/Enemy/EnemyData", order = 1)]
public class EnemiesData : ScriptableObject
{
    [SerializeField] private float _waveStartDelay;
    [SerializeField] private List<EnemyConfig> _enemies;
    public List<EnemyConfig> Enemies => _enemies;
    public float WaveStartDelay => _waveStartDelay;
}
