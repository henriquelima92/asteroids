using UnityEngine;
using UnityEngine.Events;

public class GameoverScreen : MonoBehaviour
{
    [SerializeField] private GameController _gameController;
    [SerializeField] private KeyCode _keyToPress;
    private UnityAction _returnToMainMenu;

    public void SetScreenCallbacks(UnityAction onReturnToMainMenu)
    {
        _returnToMainMenu = onReturnToMainMenu;
    }

    private void Update()
    {
        if(Input.GetKeyDown(_keyToPress))
        {
            _gameController.ResetGame();
            _returnToMainMenu?.Invoke();
        }
    }
}
