using System.Collections;
using UnityEngine;
using UnityEngine.VFX;

/// <summary>
/// g�re l'arrosoir, son stockage en eau et sa limite ainsi que l'arrosage des plantes
/// </summary>
public class WateringCan : Tool
{

    [SerializeField] float _waterToGive;
    [SerializeField] VisualEffect _waterVFX;

    /// <summary>
    /// g�re les diff�rentes possibilit�s lors de l'utilisation de l'arrosoir
    /// </summary>
    public override void Use()
    {
        base.Use();
        if (PlayerMain.Instance.Watering.WaterStorage <= 0) // si l'arrosoir est vide
        {
            print("plus d'eau");
            return;
        }

        PlayerMain.Instance.Watering.Drain();
        Destroy(Instantiate(_waterVFX, transform.position + transform.forward * ToolLength + Vector3.up / 2, Quaternion.identity), 2f);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.gameObject.TryGetComponent<PlantMain>(out PlantMain plantMain)&& plantMain.CanWater) // si c'est une plante et qu'elle peut etre arros�e
            {
                if (plantMain.PlantField == null) return;

                //Play water vfx

                plantMain.Corruption.ReduceCorruption(_waterToGive); // r�duit la corruption de la plante cibl�

                plantMain.CanWater = false;
            }
        }
    }

    public void AddWaterToGive(float waterToAdd)
    {
        _waterToGive += waterToAdd;
    }
}
