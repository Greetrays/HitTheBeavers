using UnityEngine;

public class MainMenuPanel : Screen
{
    private void Start()
    {
        Open();
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void TimeModSelected()
    {
        Debug.Log("TIME");
    }

    public void SurvivalModSelected()
    {
        Debug.Log("SURVIVAL");
    }

    public override void Open()
    {
        base.Open();
        Time.timeScale = 0;
    }
}
