using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    private BeaverView _beaver;
    public bool IsOccupited { get; private set; }

    private void Start()
    {
        IsOccupited = false;
    }

    public void Take(BeaverView beaver)
    {
        _beaver = beaver;
        _beaver.Disabled += Free;
        IsOccupited = true;
    }

    private void Free()
    {
        _beaver.Disabled -= Free;
        IsOccupited = false;
    }
}
