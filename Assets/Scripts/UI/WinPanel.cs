using UnityEngine;
using UnityEngine.SceneManagement;

public class WinPanel : Screen
{
    [SerializeField] private PlayerScore _playerScore;

    private void OnEnable()
    {
        _playerScore.Win += Open;
    }

    private void OnDisable()
    {
        _playerScore.Win -= Open;
    }

    private void Start()
    {
        Close();
    }
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public override void Open()
    {
        base.Open();
        Time.timeScale = 0;
    }
}
