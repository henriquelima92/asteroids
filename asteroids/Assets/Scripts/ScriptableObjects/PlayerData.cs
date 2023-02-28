using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Data/Player/PlayerData", order = 1)]
public class PlayerData : ScriptableObject
{

    [SerializeField] private float _respawnTime;
    [SerializeField] private List<PlayerConfig> _players;
    public List<PlayerConfig> Players => _players;
    public float RespawnTime => _respawnTime;
}
