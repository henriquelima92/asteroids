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
    [SerializeField] private Button _helpButton;
    [SerializeField] private Button _quitButton;

    private UnityAction<List<PlayerShip>> _onGameplayStart;
    private UnityAction _onHelButtonClick;

    private void Start()
    {
        _singlePlayerButton.Select();

        _singlePlayerButton.onClick.RemoveAllListeners();
        _singlePlayerButton.onClick.AddListener(() => OnPlayClick(true));

        _coopButton.onClick.RemoveAllListeners();
        _coopButton.onClick.AddListener(() => OnPlayClick(false));

        _helpButton.onClick.RemoveAllListeners();
        _helpButton.onClick.AddListener(OnHelpClick);

        _quitButton.onClick.RemoveAllListeners();
        _quitButton.onClick.AddListener(OnQuitClick);
    }

    public void SetScreenCallbacks(UnityAction<List<PlayerShip>> onGameplayStart, UnityAction onHelButtonClick)
    {
        _onGameplayStart = onGameplayStart;
        _onHelButtonClick = onHelButtonClick;
    }

    private void OnPlayClick(bool isSinglePlayer)
    {
        var players = _gameController.StartGame(isSinglePlayer);
        _onGameplayStart?.Invoke(players);
    }

    private void OnHelpClick()
    {
        _onHelButtonClick?.Invoke();
    }

    private void OnQuitClick()
    {
        Application.Quit();
    }
}
