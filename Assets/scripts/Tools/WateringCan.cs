using UnityEngine;
using UnityEngine.VFX;

/// <summary>
/// g�re l'arrosoir, son stockage en eau et sa limite ainsi que l'arrosage des plantes
/// </summary>
public class WateringCan : Tool
{
    public int _waterStorage { get; set; }

    [SerializeField] float waterToGive;
    [SerializeField] VisualEffect _waterVFX;
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
        _waterStorage -= 1; // retirer 1 d'eau a l'arrosoir
        if (_waterStorage <= 0) // si l'arrosoir est vide
        {
            print("plus d'eau");
            return;
        }
        Destroy(Instantiate(_waterVFX, transform.position + transform.forward * ToolLength + Vector3.up / 2, Quaternion.identity), 2f);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.gameObject.TryGetComponent<PlantMain>(out PlantMain plantMain)&& plantMain.CanWater) // si c'est une plante et qu'elle peut etre arros�e
            {
                print("water");
                if (plantMain.PlantField == null) return;
                plantMain.Corruption.ReduceCorruption(waterToGive); // r�duit la corruption de la plante cibl�
                // spawn particules d'eau ?
                plantMain.CanWater = false;
            }
        }
    }
}
