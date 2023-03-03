using UnityEngine;

[CreateAssetMenu(fileName = "SaucerCustomConfig", menuName = "Data/Enemy/Saucer Custom Config", order = 1)]
public class SaucerCustomConfigData : CustomConfigData
{
    [SerializeField] private SaucerEnemyConfig _config;
    public SaucerEnemyConfig Config => _config;
}