using TMPro;
using UnityEngine;

public class ScorePanel : Screen
{
    [SerializeField] private PlayerScore _playerScore;
    [SerializeField] private TMP_Text _scoreText;

    private void OnEnable()
    {
        _playerScore.Changed += OnChanged;
    }

    private void Start()
    {
        Close();
    }

    private void OnDisable()
    {
        _playerScore.Changed -= OnChanged;
    }

    private void OnChanged(int score)
    {
        _scoreText.text = score.ToString();
    }
}
