using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerHealth _health;
    [SerializeField] private PlayerScore _score;
    [SerializeField] private ModeSwitch _modeSwitch;

    public void TakeDamage(int damage)
    {
        if (_modeSwitch.GameMode == ModeSwitch.Mode.Survival)
            _health.TakeDamage(damage);
    }

    public void AddScore(int reward)
    {
        _score.AddScore(reward);
    }
}
