using System.Collections.Generic;
using UnityEngine;

public class PlayerLivesPanel : MonoBehaviour
{
    [SerializeField] private GameObject _lifePrefab;
    [SerializeField] private Transform _livesRoot;

    [SerializeField] private List<GameObject> _lives;

    public void Initialize(ILife life)
    {
        life.OnLifeAdded += AddLife;
        life.OnLifeRemoved += RemoveLife;

        _lives = new List<GameObject>();

        for(int i = 0; i < life.Lives; i++)
        {
            InstantiateLife();
        }
    }

    private void AddLife()
    {
        InstantiateLife();
    }

    private void RemoveLife()
    {
        if(_lives.Count < 1)
        {
            return;
        }

        var lastIndex = _lives.Count - 1;
        var lastLife = _lives[lastIndex];
        _lives.RemoveAt(lastIndex);

        Destroy(lastLife);
    }

    private void InstantiateLife()
    {
        var life = Instantiate(_lifePrefab, _livesRoot);
        _lives.Add(life);
    }
}
