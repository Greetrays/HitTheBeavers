using UnityEngine;
using UnityEngine.Events;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] private int _requiredScore;

    private int _currentScore;

    public event UnityAction Win;
    public event UnityAction<int> Changed;

    private void Start()
    {
        Changed?.Invoke(_currentScore);
    }

    public void AddScore(int reward)
    {
        _currentScore += reward;
        Changed?.Invoke(_currentScore);

        if (_currentScore >= _requiredScore)
        {
            Win?.Invoke();
        }
    }
}
