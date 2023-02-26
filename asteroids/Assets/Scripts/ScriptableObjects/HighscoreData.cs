using UnityEngine;

[CreateAssetMenu(fileName = "Highscore", menuName = "Data/Highscore/Highscore", order = 1)]
public class HighscoreData : ScriptableObject
{
    [SerializeField] private HighscoreConfig _highscoreConfig;
    public HighscoreConfig HighscoreConfig => _highscoreConfig;
}
