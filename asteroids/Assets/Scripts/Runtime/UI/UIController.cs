using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private MainMenuScreen _mainMenuScreen;
    [SerializeField] private GameplayScreen _gameplayScreen;
    [SerializeField] private GameoverScreen _gameoverScreen;
    [SerializeField] private HelpScreen _helpScreen;

    private void Start()
    {
        LockCursor();

        _mainMenuScreen.SetScreenCallbacks(OnGameplayStart, OnHelpScreenStart);
        _helpScreen.SetScreenCallbacks(OnReturnToMaiMenu);
        _gameoverScreen.SetScreenCallbacks(OnReturnToMaiMenu);
    }

    public void OnGameplayStart(List<PlayerShip> players)
    {
        _mainMenuScreen.gameObject.SetActive(false);
        _gameplayScreen.gameObject.SetActive(true);
        _gameplayScreen.OnGameStart(players);
    }

    public void OnGameplayFinish()
    {
        _gameoverScreen.gameObject.SetActive(true);
    }

    public void OnHelpScreenStart()
    {
        _mainMenuScreen.gameObject.SetActive(false);
        _helpScreen.gameObject.SetActive(true);
    }

    public void OnReturnToMaiMenu()
    {
        _gameplayScreen.gameObject.SetActive(false);
        _helpScreen.gameObject.SetActive(false);
        _gameoverScreen.gameObject.SetActive(false);
        _mainMenuScreen.gameObject.SetActive(true);
    }

    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
