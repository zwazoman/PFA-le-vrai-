using UnityEngine;

/// <summary>
/// gère la récupération de graines dans le champ et indique au champ qu'il a reçu une graine
/// </summary>
public class FieldStorage : Storage
{
    [field : SerializeField]  
    public Field Field { get; set; }

    /// <summary>
    /// définit les types pouvant être absorbés
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    protected override bool CanAbsorb(Item item)
    {
        return item.GetType() == typeof(Seed) || item.GetType() == typeof(Plant);
    }

    /// <summary>
    /// absorption des graines et des plantes par le champ
    /// </summary>
    /// <param name="item"></param>
    protected override void OnAbsorb(GameObject item)
    {
        if (item.TryGetComponent<Seed>(out Seed seed))
        {
            Field.Sow(item);
            Destroy(item);
        }
    }
}
