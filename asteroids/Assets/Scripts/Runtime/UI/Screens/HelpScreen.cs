using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HelpScreen : MonoBehaviour
{
    [Space, Header("Data")]
    [SerializeField] private GameData _singleGameData;
    [SerializeField] private GameData _coopGameData;
    [SerializeField] private KeyCode _keyToPress;

    [Space, Header("Panels")]
    [SerializeField] private PlayerInputInfoPanel _singlePlayerInfoPanel;
    [SerializeField] private List<PlayerInputInfoPanel> _coopPlayerInfoPanels;

    private UnityAction _returnToMainMenu;

    public void SetScreenCallbacks(UnityAction onReturnToMainMenu)
    {
        _returnToMainMenu = onReturnToMainMenu;
    }

    private void Start()
    {
        _singlePlayerInfoPanel.SetPanel(_singleGameData.PlayerData.Players[0].Inputs);

        for (int i = 0; i < _coopPlayerInfoPanels.Count; i++)
        {
            _coopPlayerInfoPanels[i].SetPanel(_coopGameData.PlayerData.Players[i].Inputs);           
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(_keyToPress))
        {
            _returnToMainMenu?.Invoke();
        }
    }
}
