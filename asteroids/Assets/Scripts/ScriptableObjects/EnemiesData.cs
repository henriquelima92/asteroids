using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct Enemy
{
    public EnemyType EnemyType;
    public GameObject EnemyPrefab;
    public int MaxAmount;
    public float MoveSpeed;
}

[CreateAssetMenu(fileName = "EnemyData", menuName = "Data/Enemy/EnemyData", order = 1)]
public class EnemiesData : ScriptableObject
{
    [SerializeField] private List<Enemy> _enemies;
    public List<Enemy> Enemies => _enemies;

    public Enemy FindEnemy(EnemyType type)
    {
        return _enemies.Find(x => x.EnemyType == type);
    }
}
