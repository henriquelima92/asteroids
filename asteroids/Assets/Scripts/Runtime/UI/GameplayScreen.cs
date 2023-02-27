using System.Collections.Generic;
using UnityEngine;

public class GameplayScreen : MonoBehaviour
{
    [SerializeField] private List<PlayerPanel> _playersGroups;

    public void OnGameStart(PlayerData playerData)
    {
        var playersAmount = playerData.Players.Count;

        for (int i = 0; i < playersAmount; i++)
        {
            var playerInfo = playerData.Players[i];
            var playerPanel = _playersGroups[i];

            playerPanel.gameObject.SetActive(true);
            playerPanel.Initialize(playerInfo.Lives);
        }

        gameObject.SetActive(true);
    }
}
