using UnityEngine;
using UnityEngine.UI;

public class TimeBar : MonoBehaviour
{
    [SerializeField] private BeaverTime _time;
    [SerializeField] private Image _bar;

    private void OnEnable()
    {
        _time.TimeChanged += OnTimeChanged;
    }

    private void OnDisable()
    {
        _time.TimeChanged -= OnTimeChanged;
    }

    private void OnTimeChanged(float maxTime, float timeLeft)
    {
        _bar.fillAmount = timeLeft / maxTime;
    }
}
