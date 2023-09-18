using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class BeaverTime : MonoBehaviour
{
    private float _lifeTime;
    private float _timeLeft;
    private Coroutine _coroutine;
    private Player _player;
    private int _damage;
    private ParticleSystem _particle;

    public event UnityAction<float, float> TimeChanged;

    public void Init(float lifeTime, Player player, int damage, ParticleSystem particle)
    {
        _lifeTime = lifeTime;
        _player = player;
        _damage = damage;
        _particle = particle;

        if (_coroutine != null )
        {
            StopCoroutine(_coroutine);
        }  
        
        _coroutine = StartCoroutine(TimeChange());
    }

    private IEnumerator TimeChange()
    {
        _timeLeft = _lifeTime;

        while (_timeLeft >= 0)
        {
            _timeLeft -= Time.deltaTime;
            TimeChanged?.Invoke(_lifeTime, _timeLeft);
            yield return null;
        }

        Instantiate(_particle, transform.position, Quaternion.identity);
        _player.TakeDamage(_damage);
        gameObject.SetActive(false);
        _coroutine = null;
    }
}