using UnityEngine;

/// <summary>
/// g�re l'arrosoir, son stockage en eau et sa limite ainsi que l'arrosage des plantes
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
    /// g�re les diff�rentes possibilit�s lors de l'utilisation de l'arrosoir
    /// </summary>
    public override void Use()
    {
        base.Use();
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.gameObject.TryGetComponent<PlantCorruption>(out PlantCorruption corruption) && corruption.CanWater) // si c'est une plante et qu'elle peut etre arros�e
            {
                if (_waterStorage <= 0) // si l'arrosoir est vide
                {
                    print("plus d'eau");
                    return;
                }

                if (corruption.CanWater == false) // si la plante a deja �t� arros�e
                {
                    print("d�ja arros�e");
                    return;
                }
                _waterStorage -= 1; // retirer 1 d'eau a l'arrosoir
                print("water");
                if (plantMain.PlantField == null) return;
                plantMain.Corruption.ReduceCorruption(waterToGive); // r�duit la corruption de la plante cibl�e
                corruption.CanWater = false;
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
