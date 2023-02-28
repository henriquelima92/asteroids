using UnityEngine;
using UnityEngine.Events;

public class PlayerPanel : MonoBehaviour
{
    [SerializeField] private PlayerHighscorePanel _highscorePanel;
    [SerializeField] private PlayerLivesPanel _livesPanel;

    public void Initialize(ILife life, IHighscore highscore)
    {
        _highscorePanel.Initialize(highscore);
        _livesPanel.Initialize(life);
    }
}
