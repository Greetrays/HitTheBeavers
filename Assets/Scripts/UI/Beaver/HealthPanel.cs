using TMPro;
using UnityEngine;

public class HealthPanel : MonoBehaviour
{
    [SerializeField] private BeaverHealth _health;
    [SerializeField] private TMP_Text _text;

    private void OnEnable()
    {
        _health.HealthChanged += OnTimeChanged;
    }

    private void OnDisable()
    {
        _health.HealthChanged -= OnTimeChanged;
    }

    private void OnTimeChanged(int health)
    {
        _text.text = health.ToString();
    }
}
