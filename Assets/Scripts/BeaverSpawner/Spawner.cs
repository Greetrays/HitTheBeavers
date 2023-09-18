using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float _minDelay;
    [SerializeField] private float _maxDelay;
    [SerializeField] private BeaverView _beaverTemplate;
    [SerializeField] private List<Beaver> _configs;
    [SerializeField] private MapSpawner _map;
    [SerializeField] private Player _player;

    private Pool<BeaverView> _pool;
    private float _elepsedTime;
    private float _delay;

    private void Start()
    {
        _pool = new Pool<BeaverView>(_beaverTemplate, transform, _map.CountCells);
        _delay = Random.Range(_minDelay, _maxDelay);
    }

    private void Update()
    {
        _elepsedTime += Time.deltaTime;      

        if (_elepsedTime >= _delay)
        {
            BeaverView newBeaver = _pool.GetFreeElement();          

            if (_map.GetRandomPosition(out Vector3 randomPosition, newBeaver))
            {
                SetObject(newBeaver, randomPosition);
                _elepsedTime = 0;
                _delay = Random.Range(_minDelay, _maxDelay);
            }
        }
    }

    private void SetObject(BeaverView newBeaver, Vector3 spawnPosition)
    {
        newBeaver.gameObject.SetActive(true);
        newBeaver.Init(_configs[Random.Range(0, _configs.Count)], _player);
        newBeaver.transform.position = spawnPosition;
    }
}
