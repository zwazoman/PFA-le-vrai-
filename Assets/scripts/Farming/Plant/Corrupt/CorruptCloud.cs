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
        TimeManager.Instance.OnHour += CloudCorrupt;
    }

    /// <summary>
    /// Gere le nuage de corruption 
    /// </summary>

    public virtual void CloudCorrupt()
    {
        if (TimeManager.Instance.Hour == 1) //tous les jours a 1h 
        {
            hitColliders = Physics.OverlapSphere(transform.position + transform.forward * CorruptLength, CorruptRange);
            foreach (var hitCollider in hitColliders)
            {
                if (hitCollider.TryGetComponent<PlantCorruption>(out PlantCorruption plantCorrupt)) //si c'est une plante
                {
                    Debug.Log("SUUUU");
                    plantCorrupt.SetCorruptionValue(plantCorrupt.corruptionValue + 0.2f); //ajoute 0.2 a la corruption actuelle
                }
            }
        }        
    }
    private void OnDestroy()
    {
        TimeManager.Instance.OnDay -= CloudCorrupt;
    }
}