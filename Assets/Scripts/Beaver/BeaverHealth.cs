using UnityEngine;
using UnityEngine.Events;

public class BeaverHealth : MonoBehaviour
{
    private int _maxHealth;
    private int _currentHealth;
    private Player _player;
    private int _reward;
    private ParticleSystem _particle;

    public event UnityAction<int> HealthChanged;

    private void OnMouseDown()
    {
        _currentHealth--;
        HealthChanged?.Invoke(_currentHealth);

        if (_currentHealth <= 0)
        {
            _player.AddScore(_reward);
            gameObject.SetActive(false);
            Instantiate(_particle, transform.position, Quaternion.identity);
        }
    }

    public void Init(int health, Player player, int reward, ParticleSystem particle)
    {
        _player = player;
        _reward = reward;
        _maxHealth = health;
        _currentHealth = _maxHealth;
        _particle = particle;
        HealthChanged?.Invoke(_currentHealth);
    }
}
