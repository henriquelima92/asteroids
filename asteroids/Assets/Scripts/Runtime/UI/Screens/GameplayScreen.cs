using System.Collections.Generic;
using UnityEngine;

public class GameplayScreen : MonoBehaviour
{
    [SerializeField] private List<PlayerPanel> _playersGroups;

    public void OnGameStart(List<PlayerShip> players)
    {
        var playersAmount = players.Count;

        for (int i = 0; i < playersAmount; i++)
        {
            var player = players[i];
            var playerPanel = _playersGroups[i];

            playerPanel.gameObject.SetActive(true);
            playerPanel.Initialize(player.Life, player.Highscore);
        }

        gameObject.SetActive(true);
    }
}
