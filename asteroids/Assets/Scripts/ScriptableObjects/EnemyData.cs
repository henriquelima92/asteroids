using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct Enemy
{
    public EnemyType EnemyType;
    public GameObject EnemyPrefab;
    public int MaxAmount;
}

[CreateAssetMenu(fileName = "EnemyData", menuName = "Data/Enemy/EnemyData", order = 1)]
public class EnemyData : ScriptableObject
{
    [SerializeField] private List<Enemy> _enemies;
    public List<Enemy> Enemies => _enemies;
}
