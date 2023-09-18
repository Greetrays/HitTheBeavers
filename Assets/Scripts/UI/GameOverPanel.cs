using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverPanel : Screen
{
    [SerializeField] private Timer _timer;
    [SerializeField] private PlayerHealth _playerHealth;

    private void OnEnable()
    {
        _timer.EndGame += Open;
        _playerHealth.Died += Open;
    }

    private void OnDisable()
    {
        _timer.EndGame -= Open;
        _playerHealth.Died -= Open;
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
