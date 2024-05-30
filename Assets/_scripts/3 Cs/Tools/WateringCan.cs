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
        PlayerMain.Instance.Watering.Drain();

        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.gameObject.TryGetComponent<Well>(out Well well)) well.ReplenishWateringCan();// si c'est un puits
        }

        if (PlayerMain.Instance.Watering.WaterStorage <= 0) return;// si l'arrosoir est vide

        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.gameObject.TryGetComponent<PlantMain>(out PlantMain plantMain)&& plantMain.CanWater) // si c'est une plante et qu'elle peut etre arros�e
            {
                //if (plantMain.PlantField == null) return;
                plantMain.CanWater = false;
                plantMain.Corruption.ReduceCorruption(_waterToGive);// r�duit la corruption de la plante cibl�
                RumbleManager.instance.RumblePulse(0.6f, 0.6f, 0.1f);
            }
        }
    }
}
