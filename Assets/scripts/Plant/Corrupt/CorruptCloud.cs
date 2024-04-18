using UnityEngine;

/// <summary>
/// Parametre le nuage de corruption
/// </summary>
public class CorruptCloud : MonoBehaviour
{
    [field: SerializeField]
    public float CorruptLength { get; private set; }
    [field: SerializeField]
    public float CorruptRange { get; private set; }
    public Collider[] hitColliders { get; private set; }
    private void Start()
    {
        TimeManager.Instance.OnDay += CloudCorrupt;
    }
    /// <summary>
    /// Gere le nuage de corruption 
    /// </summary>

    public virtual void CloudCorrupt()
    {
        hitColliders = Physics.OverlapSphere(transform.position + transform.forward * CorruptLength, CorruptRange);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.TryGetComponent<PlantCorruption>(out PlantCorruption plantCorrupt)) 
            {
                Debug.Log("SUUUU");
                plantCorrupt.corruptionValue += 0.2f;
            }
        }
    }
    private void OnDestroy()
    {
        TimeManager.Instance.OnDay -= CloudCorrupt;
    }
}
