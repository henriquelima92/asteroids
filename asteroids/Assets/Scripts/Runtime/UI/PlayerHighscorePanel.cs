using TMPro;
using UnityEngine;

public class PlayerHighscorePanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _highscoreText;
    
    public void SetHighscore(int value)
    {
        _highscoreText.text = value.ToString();
    }
}
