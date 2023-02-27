using UnityEngine;
using UnityEngine.UI;

public class MainMenuScreen : MonoBehaviour
{
    [SerializeField] private GameController _gameController;

    [Space, Header("Buttons")]
    [SerializeField] private Button _singlePlayerButton;
    [SerializeField] private Button _coopButton;
    [SerializeField] private Button _quitButton;

    private void Start()
    {
        _singlePlayerButton.onClick.RemoveAllListeners();
        _singlePlayerButton.onClick.AddListener(OnSinglePlayerClick);

        _coopButton.onClick.RemoveAllListeners();
        _coopButton.onClick.AddListener(OnCoopClick);

        _quitButton.onClick.RemoveAllListeners();
        _quitButton.onClick.AddListener(OnQuitClick);
    }

    private void OnSinglePlayerClick()
    {
        _gameController.StartGame(true);
        gameObject.SetActive(false);
    }

    private void OnCoopClick()
    {
        _gameController.StartGame(false);
        gameObject.SetActive(false);
    }

    private void OnQuitClick()
    {
        Application.Quit();
    }
}
