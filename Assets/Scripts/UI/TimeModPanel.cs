using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimeModPanel : Screen
{
    [SerializeField] private TMP_Text _timeText;
    [SerializeField] private Image _bar;
    [SerializeField] private Timer _timer;

    private void OnEnable()
    {
        _timer.TimeChanged += OnTimeChanged;
    }

    private void OnDisable()
    {
        _timer.TimeChanged -= OnTimeChanged;
    }

    void Start()
    {
        Close();
    }

    public override void Open()
    {
        base.Open();
        Time.timeScale = 1;
    }

    private void OnTimeChanged(float time, float timeLeft)
    {
        _bar.fillAmount = timeLeft / time;
        _timeText.text = Math.Round(timeLeft).ToString();
    }
}
