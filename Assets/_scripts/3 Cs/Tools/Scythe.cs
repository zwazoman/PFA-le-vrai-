using UnityEngine;
using UnityEngine.Experimental.Audio;

public class Scythe : Tool
{
    /// <summary>
    /// g�re les diff�rentes possibilit�s lors de l'utilisation
    /// </summary>
    public override void Use()
    {
        base.Use();
        foreach (var hitCollider in hitColliders)
        {
            if(hitCollider.gameObject.TryGetComponent<PlantMain>(out PlantMain plantMain)) // si c'ets une plante
            {
                if (plantMain.PlantField == null) return;
                plantMain.Harvest.Harvest(); // essaye de r�colter la plante
                RumbleManager.instance.RumblePulse(0.5f, 5f, 0.2f);
            }
        }
    }
}
