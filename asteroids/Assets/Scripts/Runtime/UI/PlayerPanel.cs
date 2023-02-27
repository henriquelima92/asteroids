using UnityEngine;

public class PlayerPanel : MonoBehaviour
{
    [SerializeField] private PlayerHighscorePanel _highscorePanel;
    [SerializeField] private PlayerLivesPanel _livesPanel;

    public void Initialize(int lives)
    {
        _highscorePanel.SetHighscore(0);
        _livesPanel.Initialize(lives);
    }

    public void SetHighscore(int score)
    {
        _highscorePanel.SetHighscore(score);
    }

    public void AddLife()
    {
        _livesPanel.AddLife();
    }
    public void RemoveLife()
    {
        _livesPanel.RemoveLife();
    }
}
