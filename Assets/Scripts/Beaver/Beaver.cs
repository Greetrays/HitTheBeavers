using UnityEngine;

[CreateAssetMenu(fileName = "Beaver", menuName = "Create new Beaver/Beaver", order = 51)]

public class Beaver : ScriptableObject
{
    [field: SerializeField] public int Health;
    [field: SerializeField] public float LifeTime;
    [field: SerializeField] public Mesh Model;
    [field: SerializeField] public int Reward;
    [field: SerializeField] public int Damage;
    [field: SerializeField] public Material ColorMaterial;
    [field: SerializeField] public ParticleSystem DieParticle;
    [field: SerializeField] public ParticleSystem WinParticle;
}
