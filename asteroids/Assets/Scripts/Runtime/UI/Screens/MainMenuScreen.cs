using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MainMenuScreen : MonoBehaviour
{
    [SerializeField] private GameController _gameController;

    [Space, Header("Buttons")]
    [SerializeField] private Button _singlePlayerButton;
    [SerializeField] private Button _coopButton;
    [SerializeField] private Button _quitButton;

    private UnityAction<List<PlayerShip>> _onGameplayStart;

    private void Start()
    {
        _singlePlayerButton.Select();

        _singlePlayerButton.onClick.RemoveAllListeners();
        _singlePlayerButton.onClick.AddListener(() => OnPlayClick(true));

        _coopButton.onClick.RemoveAllListeners();
        _coopButton.onClick.AddListener(() => OnPlayClick(false));

        _quitButton.onClick.RemoveAllListeners();
        _quitButton.onClick.AddListener(OnQuitClick);
    }

    public void SetScreenCallbacks(UnityAction<List<PlayerShip>> onGameplayStart)
    {
        _onGameplayStart = onGameplayStart;
    }

    private void OnPlayClick(bool isSinglePlayer)
    {
        var players = _gameController.StartGame(isSinglePlayer);
        _onGameplayStart?.Invoke(players);
    }

    private void OnQuitClick()
    {
        Application.Quit();
    }
}
