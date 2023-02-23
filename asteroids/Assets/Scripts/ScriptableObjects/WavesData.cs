using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyWave", menuName = "Data/Waves/EnemyWave", order = 1)]
public class WavesData : ScriptableObject
{
    [SerializeField] private List<EnemyWave> _waves;
    public List<EnemyWave> Waves => _waves;
}
