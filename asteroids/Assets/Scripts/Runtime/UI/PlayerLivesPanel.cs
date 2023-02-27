using System.Collections.Generic;
using UnityEngine;

public class PlayerLivesPanel : MonoBehaviour
{
    [SerializeField] private GameObject _lifePrefab;
    [SerializeField] private Transform _livesRoot;

    private List<GameObject> _lives;

    public void Initialize(int lives)
    {
        _lives = new List<GameObject>();

        for(int i = 0; i < lives; i++)
        {
            InstantiateLife();
        }
    }

    public void AddLife()
    {
        InstantiateLife();
    }

    public void RemoveLife()
    {
        if(_lives.Count > 0)
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
