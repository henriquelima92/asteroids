using TMPro;
using UnityEngine;

public class PlayerHighscorePanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _highscoreText;
    
    public void Initialize(IHighscore highscore)
    {
        highscore.OnHighscoreSet += SetScore;
        SetScore(highscore.CurrentHighscore);
    }

    private void SetScore(int score)
    {
        _highscoreText.text = score.ToString();
    }
}
