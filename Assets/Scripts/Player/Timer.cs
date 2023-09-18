using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    [SerializeField] private float _time;
    [SerializeField] private ModeSwitch _modeSwitch;

    private float _timeLeft;

    public event UnityAction<float, float> TimeChanged;
    public event UnityAction EndGame;

    public void StartTimer()
    {
        if (_modeSwitch.GameMode == ModeSwitch.Mode.Time)
            StartCoroutine(TimeChange());
    }

    private IEnumerator TimeChange()
    {
        _timeLeft = _time;

        while (_timeLeft >= 0)
        {
            _timeLeft -= Time.deltaTime;
            TimeChanged?.Invoke(_time, _timeLeft);
            yield return null;
        }

        EndGame?.Invoke();
    }
}
