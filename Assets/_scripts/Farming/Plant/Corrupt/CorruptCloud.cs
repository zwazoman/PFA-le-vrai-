using UnityEngine;

/// <summary>
/// Parametre le nuage de corruption
/// </summary>
public class CorruptCloud : MonoBehaviour
{

    [field: SerializeField]
    public float Range { get; private set; }

    [SerializeField] float  CorruptionStrength = 0.2f;
    public Collider[] hitColliders { get; private set; }
    private void Start()
    {
        TimeManager.Instance.OnDay += CloudCorrupt;
    }

    /// <summary>
    /// applique de la corruption sur toutes les plantes dans le nuage , si il est 1h du matin
    /// </summary>

    public virtual void CloudCorrupt()
    {
        if (TimeManager.Instance.Hour == 1) //tous les jours a 1h 
        {
            hitColliders = Physics.OverlapSphere(transform.position , Range);
            foreach (var hitCollider in hitColliders)
            {
                if (hitCollider.TryGetComponent<PlantCorruption>(out PlantCorruption plantCorrupt)) //si c'est une plante
                {
                    plantCorrupt.SetCorruptionValue(plantCorrupt.corruptionValue + CorruptionStrength); //ajoute x a la corruption actuelle
                }
            }
        }        
    }
    private void OnDestroy()
    {
        TimeManager.Instance.OnDay -= CloudCorrupt;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, Range);
    }
}