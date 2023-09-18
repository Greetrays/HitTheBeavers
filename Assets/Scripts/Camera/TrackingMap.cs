using UnityEngine;
using Cinemachine;

public class TrackingMap : MonoBehaviour
{
    [SerializeField] private CinemachineTargetGroup _cinemachine;
    [SerializeField] private MapSpawner _mapSpawner;

    private void OnEnable()
    {
        _mapSpawner.Generated += OnGenerated;
    }

    private void OnDisable()
    {
        _mapSpawner.Generated -= OnGenerated;
    }

    private void OnGenerated()
    {
        CinemachineTargetGroup.Target[] targets = new CinemachineTargetGroup.Target[2]
{
            new CinemachineTargetGroup.Target{target = _mapSpawner.FirstCell, radius = 0, weight = 1 },
            new CinemachineTargetGroup.Target{target = _mapSpawner.LastCell, radius = 0, weight = 1 }
};

        _cinemachine.m_Targets = targets;
    }
}
