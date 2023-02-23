using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameData", menuName = "Data/GameData/GameData", order = 1)]
public class GameData : ScriptableObject
{
    [Space, Header("Map Boundaries")]
    [SerializeField] private MapBoundariesData _mapBoundariesData;

    [Space, Header("Players")]
    [SerializeField] private PlayerData _playerData;

    [Space, Header("Waves")]
    [SerializeField] private WavesData _wavesData;

    [Space, Header("Enemies")]
    [SerializeField] private EnemyData _enemiesData;

    public MapBoundariesData MapBoundariesData => _mapBoundariesData;
    public PlayerData PlayerData => _playerData;
    public WavesData WaveData => _wavesData;
    public EnemyData EnemiesData => _enemiesData;
}
