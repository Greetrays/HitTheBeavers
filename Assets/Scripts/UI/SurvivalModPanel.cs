using TMPro;
using UnityEngine;

public class SurvivalModPanel : Screen
{
    [SerializeField] private TMP_Text _healthText;
    [SerializeField] private PlayerHealth _health;

    private void Start()
    {
        Close();
    }

    private void OnEnable()
    {
        _health.Changed += OnChanged;
    }

    private void OnDisable()
    {
        _health.Changed -= OnChanged;
    }

    public override void Open()
    {
        base.Open();
        Time.timeScale = 1;
    }

    private void OnChanged(int health)
    {
        _healthText.text = health.ToString();
    }
}
