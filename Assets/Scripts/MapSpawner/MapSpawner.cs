using UnityEngine;
using UnityEngine.Events;
using System.Linq;
using System.Collections.Generic;

public class MapSpawner : MonoBehaviour
{
    [SerializeField, Range(2, 10)] private int _rowCount;
    [SerializeField, Range(2, 10)] private int _columnCount;
    [SerializeField] private SpawnPoint _spawnPointTemplate;
    [SerializeField, Range(1f, 10f)] private float _spacing;

    private SpawnPoint[,] _spawnPoints;

    public event UnityAction Generated;

    public Transform FirstCell { get; private set; }
    public Transform LastCell { get; private set; }
    public int CountCells => _rowCount * _columnCount;

    private void OnValidate()
    {
        if (_spacing < 1)
        {
            _spacing = 1;
        }
    }

    private void Start()
    {
        _spawnPoints = new SpawnPoint[_rowCount, _columnCount];

        for (int i = 0; i < _rowCount; i++)
        {
            for (int j = 0; j < _columnCount; j++)
            {
                Vector3 newPosition = new Vector3(transform.position.x + _spacing * i, 0, transform.position.z + _spacing * j);
                SpawnPoint newSpawnPoint = Instantiate(_spawnPointTemplate, newPosition, Quaternion.identity, transform);
                _spawnPoints[i, j] = newSpawnPoint;
            }
        }

        FirstCell = _spawnPoints[0, 0].transform;
        LastCell = _spawnPoints[_rowCount - 1, _columnCount - 1].transform;
        Generated?.Invoke();
    }

    public bool GetRandomPosition(out Vector3 randomPosition, BeaverView beaver)
    {
        List<SpawnPoint> freeElements = GetFreeElements();
        randomPosition = Vector3.zero;

        if (freeElements.Count > 0)
        {
            int randomIndex = Random.Range(0, freeElements.Count);
            freeElements[randomIndex].Take(beaver);
            randomPosition = freeElements[randomIndex].transform.position;
            return true;
        }

        return false;
    }

    private List<SpawnPoint> GetFreeElements()
    {
        List<SpawnPoint> freeElements = new List<SpawnPoint>();

        for (int i = 0; i < _rowCount; i++)
        {
            for (int j = 0; j < _columnCount; j++)
            {
                if (_spawnPoints[i, j].IsOccupited == false)
                {
                    freeElements.Add(_spawnPoints[i, j]);
                }
            }
        }

        return freeElements;
    }
}