using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int _maxHealth;

    private int _currentHealth;

    public event UnityAction Died;
    public event UnityAction<int> Changed;

    private void Start()
    {
        _currentHealth = _maxHealth;
        Changed?.Invoke(_currentHealth);
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);
        Changed?.Invoke(_currentHealth);

        if (_currentHealth <= 0)
        {
            Died?.Invoke();
        }
    }
}
