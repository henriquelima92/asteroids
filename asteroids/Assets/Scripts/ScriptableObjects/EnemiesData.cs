using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public struct Enemy
{
    public EnemyType EnemyType;
    public AsteroidPool Pool;
    public FloatRange MoveSpeed;
    public int Score;
}

[CreateAssetMenu(fileName = "EnemyData", menuName = "Data/Enemy/EnemyData", order = 1)]
public class EnemiesData : ScriptableObject
{
    [SerializeField] private float _waveStartDelay;
    [SerializeField] private List<Enemy> _enemies;
    public List<Enemy> Enemies => _enemies;
    public float WaveStartDelay => _waveStartDelay;

    public Enemy FindEnemy(EnemyType type)
    {
        return _enemies.Find(x => x.EnemyType == type);
    }
}
