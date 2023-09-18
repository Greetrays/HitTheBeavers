using UnityEngine;
using UnityEngine.Events;

public class BeaverView : MonoBehaviour
{
    [SerializeField] private MeshFilter _model;
    [SerializeField] private BeaverHealth _health;
    [SerializeField] private BeaverTime _time;
    [SerializeField] private MeshRenderer _renderer;

    public event UnityAction Disabled;

    private void OnDisable()
    {
        Disabled?.Invoke();
    }

    public void Init(Beaver beaverConfig, Player player)
    {
        _model.mesh = beaverConfig.Model;
        _health.Init(beaverConfig.Health, player, beaverConfig.Reward, beaverConfig.DieParticle);
        _time.Init(beaverConfig.LifeTime, player, beaverConfig.Damage, beaverConfig.WinParticle);
        _renderer.material = beaverConfig.ColorMaterial;
    }
}
