using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Data/Player/PlayerData", order = 1)]
public class PlayerData : ScriptableObject
{

    [SerializeField] private float _respawnTime;
    [SerializeField] private List<Player> _players;
    public List<Player> Players => _players;
    public float RespawnTime => _respawnTime;
}
