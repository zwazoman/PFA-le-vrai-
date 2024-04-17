using UnityEngine;

/// <summary>
/// gère l'arrosoir, son stockage en eau et sa limite ainsi que l'arrosage des plantes
/// </summary>
public class WateringCan : Tool
{
    private int _waterStorage;

    [SerializeField] float waterToGive;
    [field : SerializeField]
    public int MaxWaterStorage { get; set; }

    private void Awake()
    {
        _waterStorage = MaxWaterStorage; // l'arrosoir est rempli
    }

    /// <summary>
    /// gère les différentes possibilités lors de l'utilisation de l'arrosoir
    /// </summary>
    public override void Use()
    {
        base.Use();
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.gameObject.TryGetComponent<PlantCorruption>(out PlantCorruption corruption)) // si c'est une plante
            {
                if (_waterStorage <= 0) // si l'arrosoir est vide
                {
                    print("plus d'eau");
                    return;
                }
                _waterStorage -= 1; // retirer 1 d'eau a l'arrosoir
                print("water");
                corruption.ReduceCorruption(waterToGive); // réduit la corruption de la plante ciblée
                // spawn particules d'eau ?
            }
            if(hitCollider.gameObject.TryGetComponent<Well>(out Well well)) // si c'est un puit
            {
                print("replenish water");
                _waterStorage = MaxWaterStorage; // remplir l'arrosoir
            }
        }

    }
}
