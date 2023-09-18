using UnityEngine;

public class ModeSwitch : MonoBehaviour
{
    public enum Mode
    {
        Time,
        Survival
    }

    public Mode GameMode { get; private set; }
     
    public void SelectTimeMode()
    {
        GameMode = Mode.Time;
    }

    public void SelectSurvivalMode()
    {
        GameMode = Mode.Survival;
    }
}
